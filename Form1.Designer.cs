namespace Simple_Traffic_Light_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trafficLight1 = new Simple_Traffic_Light_Project.TrafficLight();
            this.SuspendLayout();
            // 
            // trafficLight1
            // 
            this.trafficLight1.BackColor = System.Drawing.Color.White;
            this.trafficLight1.GreenTime = 5;
            this.trafficLight1.Location = new System.Drawing.Point(1, 1);
            this.trafficLight1.Name = "trafficLight1";
            this.trafficLight1.OrangeTime = 5;
            this.trafficLight1.RedTime = 5;
            this.trafficLight1.Size = new System.Drawing.Size(93, 195);
            this.trafficLight1.TabIndex = 0;
            this.trafficLight1.TrafficMode = Simple_Traffic_Light_Project.TrafficLight.enTraffic.Red;
            this.trafficLight1.RedLightOn += new System.EventHandler<Simple_Traffic_Light_Project.TrafficLight.TraficLightEventArgs>(this.trafficLight1_RedLightOn);
            this.trafficLight1.OrangeLightOn += new System.EventHandler<Simple_Traffic_Light_Project.TrafficLight.TraficLightEventArgs>(this.trafficLight1_OrangeLightOn);
            this.trafficLight1.GreenLightOn += new System.EventHandler<Simple_Traffic_Light_Project.TrafficLight.TraficLightEventArgs>(this.trafficLight1_GreenLightOn);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 352);
            this.Controls.Add(this.trafficLight1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TrafficLight trafficLight1;
    }
}

