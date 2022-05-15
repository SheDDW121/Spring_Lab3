using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClassLibrary;

namespace WPF_ViewModel
{
    public interface IErrorReporter
    {
        void ReportError(string message);
    }
    public class MainViewModel : ViewModelBase, IDataErrorInfo
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        public void PropertiesChanged()
        {
            RaisePropertyChanged(nameof(M_Data_0));
            RaisePropertyChanged(nameof(M_Data_1));
            RaisePropertyChanged(nameof(M_Data_2));
            RaisePropertyChanged(nameof(Sp_I_0));
            RaisePropertyChanged(nameof(Sp_I_1));
            RaisePropertyChanged(nameof(Sp_I_2));
        }
        public string Error { get { return "Error"; } }

        public string this[string property] //I know, that here much better was to use switch, not a lot of if's, whatever
        {                                   //And actually here's a lot of symbols, but I don't have ToolTips - these strings aren't needed
            get
            {
                string msg = null;
                if (property == nameof(M_Data_1))
                {
                    if (M_Data_1 >= M_Data_2)
                    {
                        msg = "a must be less than b";
                    }
                }
                else if (property == nameof(M_Data_2))
                {
                    if (M_Data_2 <= M_Data_1)
                    {
                        msg = "b must be greater than a";
                    }
                }
                else if (property == nameof(M_Data_0))
                {
                    if (M_Data_0 <= 2)
                    {
                        msg = "nx must be greater than 2";
                    }
                }

                else if (property == nameof(nx_spl))
                {
                    if (nx_spl <= 2)
                    {
                        msg = "number of spline nodes must be greater than 2";
                    }
                }
                else if (property == nameof(Sp_I_0))
                {
                    if (Sp_I_0 < M_Data_1)
                    {
                        msg = "x1 must be not less than a";
                    }

                    else if (Sp_I_0 >= Sp_I_1)
                    {
                        msg = "x1 must be less than x2";
                    }
                }
                else if (property == nameof(Sp_I_1))
                {
                    if (Sp_I_1 <= Sp_I_0)
                    {
                        msg = "x2 must be not less than x1";
                    }

                    else if (Sp_I_1 >= Sp_I_2)
                    {
                        msg = "x2 must be less than x3";
                    }
                }
                else if (property == nameof(Sp_I_2))
                {
                    if (Sp_I_2 <= Sp_I_1)
                    {
                        msg = "x3 must be greater than x2";
                    }

                    else if (Sp_I_2 > M_Data_2)
                    {
                        msg = "x3 must be not greater than b";
                    }
                }
                return msg;
            }
        }
        public SplineParametres Sp_Par { get; set; } = new SplineParametres();
        public SplinesData Sp_Data { get; set; }
        public ObservableCollection<string> Measured_Items { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Spline_Der { get; set; } = new ObservableCollection<string>();
        public double[] Deriv { get; set; } = new double[6];
        public MeasuredData Measured { get; set; }
        public double[] M_Data { get; set; } = new double[3] { 10, 0, 2 };

        public OxyPlotData OxyPlot_D { get; set; }
        private IErrorReporter errorReporter;
        public double M_Data_0
        {
            get => M_Data[0];
            set
            {
                M_Data[0] = value;
            }
        }
        public double M_Data_1
        {
            get => M_Data[1];
            set
            {
                M_Data[1] = value;
                PropertiesChanged();
            }
        }
        public double M_Data_2
        {
            get => M_Data[2];
            set
            {
                M_Data[2] = value;
                PropertiesChanged();
            }
        }

        public int nx_spl
        {
            get => Sp_Par.nx;
            set
            {
                Sp_Par.nx = value;
            }
        }
        public double Sp_I_0
        {
            get => Sp_Par.integral_limits[0];
            set
            {
                Sp_Par.integral_limits[0] = value;
                PropertiesChanged();
            }
        }

        public double Sp_I_1
        {
            get => Sp_Par.integral_limits[1];
            set
            {
                Sp_Par.integral_limits[1] = value;
                PropertiesChanged();
            }
        }

        public double Sp_I_2
        {
            get => Sp_Par.integral_limits[2];
            set
            {
                Sp_Par.integral_limits[2] = value;
                PropertiesChanged();
            }
        }

        public Spf F_Fun { get; set; }
        public bool Uniform { get => !not_Uniform; }
        public bool not_Uniform { get; set; }
        public ICommand MakeMeasureCommand { get; private set; }
        public ICommand MakeSplineCommand { get; private set; }

        public MainViewModel (IErrorReporter ER)
        {
            errorReporter = ER;
            MakeMeasureCommand = new RelayCommand(_ => 
            {
                Do_Make_Measured(this);
                RaisePropertyChanged(nameof(OxyPlot_D));
            },  CanMakeMeasured
            );

            MakeSplineCommand = new RelayCommand(_ =>
            {
                Do_Make_Spline(this);
                RaisePropertyChanged(nameof(OxyPlot_D));
            }, CanMakeSpline
            );
        }

        //Further - Command handlers - for CanExecute and Execute
        private void Do_Make_Measured(object sender)
        {
            try
            {
                
                this.Measured = new MeasuredData((int)this.M_Data[0], this.M_Data[1], this.M_Data[2], this.Uniform, this.F_Fun);
                this.Measured_Items.Clear();
                this.Spline_Der.Clear();
                for (int i = 0; i < this.Measured.nx; i++)
                {
                    this.Measured_Items.Add($"x = {this.Measured.nodes_arr[i].ToString("F3")}\ty = {this.Measured.values[i].ToString("F3")}");
                }
                this.Sp_Data = new SplinesData(this.Measured, new SplineParametres());
                OxyPlot_D = new OxyPlotData(this.Sp_Data);
            }
            catch (Exception ex)
            {
                errorReporter.ReportError(ex.Message);
            }
        }

        private bool CanMakeMeasured(object sender)
        {
            if ((M_Data_1 >= M_Data_2) || (M_Data_2 <= M_Data_1) || (M_Data_0 <= 2))
            {
                return false;
            }
            return true;
        }
        private void Do_Make_Spline(object sender)
        {
            try
            {
                this.Sp_Data.Spl_Data = new SplineParametres(this.Sp_Data.M_Data.start, this.Sp_Data.M_Data.end, this.Sp_Par.nx);
                this.Sp_Data.Spl_Data.integral_limits = this.Sp_Par.integral_limits;

                this.Deriv = this.Sp_Data.Start_MKL();
                this.Spline_Der.Clear();

                this.Spline_Der.Add("Левая Точка (а):");
                this.Spline_Der.Add($"   Значение = {this.Deriv[0].ToString("F3")}");
                this.Spline_Der.Add($"   1-я производная = {this.Deriv[1].ToString("F3")}");
                this.Spline_Der.Add($"   2-я производная = {this.Deriv[2].ToString("F3")}\n");

                this.Spline_Der.Add("Правая Точка (b):");
                this.Spline_Der.Add($"   Значение = {this.Deriv[3].ToString("F3")}");
                this.Spline_Der.Add($"   1-я производная = {this.Deriv[4].ToString("F3")}");
                this.Spline_Der.Add($"   2-я производная = {this.Deriv[5].ToString("F3")}\n");

                this.Spline_Der.Add("Интегралы:");
                this.Spline_Der.Add($"   [x1, x2] = {this.Sp_Data.Integrals_Values[0].ToString("F3")}");
                this.Spline_Der.Add($"   [x2, x3] = {this.Sp_Data.Integrals_Values[1].ToString("F3")}");
                this.Spline_Der.Add($"   [x1, x3] = {this.Sp_Data.Integrals_Values[2].ToString("F3")}");

                OxyPlot_D = new OxyPlotData(this.Sp_Data);
            }
            catch (Exception ex)
            {
                errorReporter.ReportError(ex.Message);
            }
        }

        private bool CanMakeSpline(object sender)
        {
            if (this.nx_spl <= 2 || this.Sp_I_0 >= this.Sp_I_1 || Sp_I_1 >= Sp_I_2 || Sp_I_0 < M_Data_1 || Sp_I_2 > M_Data_2 || this.Measured_Items.Count == 0)
                return false;
            return true;
        }
    }
}
