using Simple_Traffic_Light_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Simple_Traffic_Light_Project.TrafficLight;

namespace Simple_Traffic_Light_Project
{
    public partial class TrafficLight : UserControl
    {
        public enum enTraffic { Green = 0, Orange = 1, Red = 2 }
        private enTraffic _TrafficMode = enTraffic.Red;

        private int _CounterDownTime;

        public class TraficLightEventArgs : EventArgs
        {
            public enTraffic TrafficMode { get; set; }
            public int CounterDownTime { get; set; }

            public TraficLightEventArgs(enTraffic trafficMode, int counterDownTime)
            {
                this.TrafficMode = trafficMode;
                this.CounterDownTime = counterDownTime;
            }
        }

        public event EventHandler<TraficLightEventArgs> RedLightOn;
        public void RaiseRedLightOn()
        {
            RaiseRedLightOn(new TraficLightEventArgs(enTraffic.Red, _RedTime));
        }
        protected virtual void RaiseRedLightOn(TraficLightEventArgs e)
        {
            RedLightOn?.Invoke(this, e);
        }

        public event EventHandler<TraficLightEventArgs> RedLightOff;

        public void RaiseRedLightOff()
        {
            RaiseRedLightOff(new TraficLightEventArgs(enTraffic.Orange, _OrangeTime));
        }

        protected virtual void RaiseRedLightOff(TraficLightEventArgs e)
        {
            RedLightOn?.Invoke(this, e);
        }


        public event EventHandler<TraficLightEventArgs> OrangeLightOn;
        public void RaiseOrangeLightOn()
        {
            RaiseOrangeLightOn(new TraficLightEventArgs(enTraffic.Orange, _OrangeTime));
        }
        protected virtual void RaiseOrangeLightOn(TraficLightEventArgs e)
        {
            OrangeLightOn?.Invoke(this, e);
        }


        public event EventHandler<TraficLightEventArgs> GreenLightOn;
        public void RaiseGreenLightOn()
        {
            RaiseGreenLightOn(new TraficLightEventArgs(enTraffic.Green, _GreenTime));
        }
        protected virtual void RaiseGreenLightOn(TraficLightEventArgs e)
        {
            GreenLightOn?.Invoke(this, e);
        }

        public event EventHandler<TraficLightEventArgs> GreenLightOff;
        public void RaiseGreenLightOff()
        {
            RaiseGreenLightOff(new TraficLightEventArgs(enTraffic.Orange, _OrangeTime));
        }
        protected virtual void RaiseGreenLightOff(TraficLightEventArgs e)
        {
            RedLightOn?.Invoke(this, e);
        }
        public TrafficLight()
        {
            InitializeComponent();
        }
        private int CountDownTime()
        {
            switch (_TrafficMode)
            {
                case enTraffic.Green:
                    return GreenTime;
                case enTraffic.Orange:
                    return OrangeTime;
                case enTraffic.Red:
                    return RedTime;
                default:
                    return RedTime;
            }
            
        }

        public enTraffic TrafficMode
        {
            get { return _TrafficMode; }
            set
            {
                _TrafficMode = value;

               switch(_TrafficMode)
                {
                    case enTraffic.Green:
                        pbTrafficLight.Image = Resources.Green;
                        lblTime.ForeColor = Color.Green;
                        
                        break;
                    case enTraffic.Orange:
                        pbTrafficLight.Image = Resources.Orange;
                        lblTime.ForeColor = Color.Orange;
                       
                        break;
                    case enTraffic.Red:
                        pbTrafficLight.Image = Resources.Red;
                        lblTime.ForeColor = Color.Red;
                        
                        break;
                    default:lblTime.ForeColor = Color.Red;
                        break;
                }
            }
            
        }

        private int _RedTime = 10;
        private int _GreenTime = 5;
        private int _OrangeTime = 5;

        public int RedTime
        {
            get { return _RedTime; }
            set { _RedTime = value; }
        }

        public int OrangeTime
        {
            get { return _OrangeTime; }
            set { _OrangeTime = value; }
        }

        public int GreenTime
        {
            get { return _GreenTime; }
            set { _GreenTime = value; }
        }

        private enTraffic _TrafficAfterGreenOrangeOrRed;
        private void ChangeLight()
        {

            switch(_TrafficMode)
            {

                case enTraffic.Red:
                    _TrafficAfterGreenOrangeOrRed = enTraffic.Green;
                    TrafficMode = enTraffic.Orange;
                    _CounterDownTime = OrangeTime;
                    lblTime.Text = _CounterDownTime.ToString();
                    RaiseOrangeLightOn();
                    break;
                case enTraffic.Orange:
                    if(_TrafficAfterGreenOrangeOrRed == enTraffic.Green)
                    {
                        TrafficMode = enTraffic.Green;
                        _CounterDownTime = GreenTime;
                        lblTime.Text = _CounterDownTime.ToString();
                        RaiseGreenLightOn();    
                        break;
                    }
                    else
                    {
                        TrafficMode = enTraffic.Red;
                        _CounterDownTime = RedTime;
                        lblTime.Text = _CounterDownTime.ToString();
                        RaiseRedLightOn();
                        break;
                    }
                case enTraffic.Green:
                    _TrafficAfterGreenOrangeOrRed = enTraffic.Red;
                    TrafficMode = enTraffic.Orange;
                    _CounterDownTime = OrangeTime;
                    lblTime.Text = _CounterDownTime.ToString();
                    RaiseOrangeLightOn();
                    break;
                default:pbTrafficLight.Image = Resources.Red;
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = _CounterDownTime.ToString();
            if(_CounterDownTime==0)
            {
                ChangeLight();
            }
            else
            {
                --_CounterDownTime;
            }
        }

        public void Stop()
        {
            timer1.Stop();
        }
        public void Start()
        {
            _CounterDownTime = CountDownTime();
            timer1.Start();
        }
        private void TrafficLight_Load(object sender, EventArgs e)
        {
            
        }
    }
}
