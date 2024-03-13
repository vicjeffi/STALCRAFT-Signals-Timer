using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WK.Libraries.HotkeyListenerNS;
using System.Windows.Input;
using System.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace STALCRAFT_Signals_timer
{
    public partial class Form1 : Form
    {
        private string BindKey { get; set; }
        private SoundPlayer simpleSound = new SoundPlayer(STALCRAFT_Signals_timer.Properties.Resources.pda_);
        private int TimerTime { get; set; }

        private ToolStripComboBox bindsComboBox;
        private ToolStripTextBox timeTextBox;

        private HotkeyListener hkl = new HotkeyListener();
        private Hotkey hotkey1;
        public Form1()     
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon.Icon = Icon.FromHandle(STALCRAFT_Signals_timer.Properties.Resources._3F3F3F3F_3F3F3F_3F3F3F3F3F3F3F.GetHicon());
            notifyIcon.Visible = true;
            notifyIcon.Text = "Таймер сигналов (не активен)";
            notifyIcon.Visible = true;

            bindsComboBox = (contextMenuStrip.Items[0] as ToolStripComboBox);
            timeTextBox = (contextMenuStrip.Items[1] as ToolStripTextBox);
            var exitAppBox = (contextMenuStrip.Items[3] as ToolStripMenuItem);

            foreach (var fruit in Enum.GetValues(typeof(Keys)))
            {
                bindsComboBox.Items.Add(fruit.ToString());
            }

            // Bind Key
            if (Properties.Settings.Default.KeyBind != "") 
            {
                bindsComboBox.SelectedItem = Properties.Settings.Default.KeyBind;
                hotkey1 = new Hotkey(Properties.Settings.Default.KeyBind);
            }
            else // if its first app load
            {
                Properties.Settings.Default.KeyBind = Key.NumPad0.ToString();
                bindsComboBox.SelectedItem = Properties.Settings.Default.KeyBind;
                hotkey1 = new Hotkey(Properties.Settings.Default.KeyBind);
            }

            // Timer Time
            if (Properties.Settings.Default.TimerTime != 0)
            {
                TimerTime = Properties.Settings.Default.TimerTime;
                timer1.Interval = TimerTime * 1000;
                timeTextBox.Text = TimerTime.ToString();
            }
            else // if its first app load
            {
                Properties.Settings.Default.TimerTime = 180;
                TimerTime = Properties.Settings.Default.TimerTime;
                timer1.Interval = TimerTime * 1000;
                timeTextBox.Text = TimerTime.ToString();
            }

            bindsComboBox.SelectedIndexChanged += BindsComboBox_SelectedIndexChanged;
            timeTextBox.KeyDown += TimeTextBox_KeyDown; ;
            timeTextBox.KeyPress += TimeComboBox_KeyPress;
            exitAppBox.Click += ExitAppBox_Click;
            timer1.Tick += Timer1_Tick;

            hkl.Add(hotkey1);
            hkl.HotkeyPressed += Hkl_HotkeyPressed;
        }
        private void ExitAppBox_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            simpleSound.Play();
            timer1.Stop();
            notifyIcon.Text = "Таймер сигналов (не активен)";
        }

        private void TimeComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as ToolStripTextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BindsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindKey = bindsComboBox.SelectedItem as string;
            Properties.Settings.Default.KeyBind = BindKey;
            Properties.Settings.Default.Save();

            hkl.Update(ref hotkey1, new Hotkey(BindKey));
            contextMenuStrip.Close();
        }
        private void TimeTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimerTime = int.Parse(timeTextBox.Text);
                Properties.Settings.Default.TimerTime = TimerTime;
                Properties.Settings.Default.Save();

                if(timer1.Enabled == true)
                {
                    timer1.Stop();
                    MessageBox.Show("Таймер завершен, а время обновленно", "Внимание!");
                }

                timer1.Interval = TimerTime * 1000;
                contextMenuStrip.Close();
            }
        }

        private void Hkl_HotkeyPressed(object sender, HotkeyEventArgs e)
        {
            if (e.Hotkey == hotkey1)
            {
                notifyIcon.Text = "Таймер сигналов (активен)";
                timer1.Start();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
        }
    }
}
