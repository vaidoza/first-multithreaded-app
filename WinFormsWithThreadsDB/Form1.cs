using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;   //TODO: reiks pasalinti
using System.Threading;

namespace WinFormsWithThreadsDB
{



    public partial class Form1 : Form
    {
        //ThreadWorker threadwork = new ThreadWorker();
        Thread _thread;
        ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        ManualResetEvent _pauseEvent = new ManualResetEvent(true);
        public delegate void UpdatelistView(string thrId,string thrtxt);
        public bool IsCancelled { get; set; }
        
        public Form1()
        {
            InitializeComponent();

        }


        //void DeleteFromAccessTable()
        //{
        //    using (OleDbConnection conn = new OleDbConnection(connectionString))
        //    {
        //        string deleteqerystr = "";
        //        deleteqerystr = "DELETE FROM ThreadsLog WHERE id IN (3,4,5,7);";
        //        using (OleDbCommand cmd = new OleDbCommand(deleteqerystr, conn))
        //        {
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            //conn.Close();
        //        }
        //    }
        //}

        private void btnStart_Click(object sender, EventArgs e)
        {
            int counter = 0;
            IsCancelled = false;

            if ((!txtbxThreadCnt.Text.All(c => Char.IsNumber(c)))||(txtbxThreadCnt.Text==""))
            {
                MessageBox.Show("Error on 'Threads count' field: selected value is NaN!", "Application error",    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if ((Int32.Parse(txtbxThreadCnt.Text)>1) && (Int32.Parse(txtbxThreadCnt.Text) < 16))
                {
                    listViewThreadCtrl.Items.Clear();
                    DMLTools dmltool = new DMLTools();

                    List<ThreadData> tdlist = dmltool.ThreadListTable();
                    foreach (var item in tdlist)
                    {
                        ListViewItem lvitem = new ListViewItem((++counter).ToString());
                        lvitem.SubItems.Add(item.threadId.ToString());
                        lvitem.SubItems.Add(item.threadData.ToString());
                        listViewThreadCtrl.Items.Add(lvitem);
                    }
                    for (int i = 0; i < Int32.Parse(txtbxThreadCnt.Text); i++)
                    {
                        Start((i + 1).ToString());
                    }

                    btnStop.Enabled = true;
                    btnStart.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error on 'Threads count' field: Wrong number. Valid value range is [2..15]!", "Application error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtbxThreadCnt.Text = "2";
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            IsCancelled = true;
            Stop();
            btnStop.Enabled = false;
            btnStart.Enabled = true;

        }

        private void UpdateUI(string thrid,string thrtxt)
        {
            int counter = 0;

            ListViewItem lvitem = new ListViewItem((++counter).ToString());
            lvitem.SubItems.Add(thrid);
            lvitem.SubItems.Add(thrtxt);
            listViewThreadCtrl.Items.Insert(0, lvitem);

            for (int i = 1; i < listViewThreadCtrl.Items.Count; i++)
            {
                listViewThreadCtrl.Items[i].SubItems[0].Text = (i+1).ToString();

            }
            if (listViewThreadCtrl.Items.Count>=20)
            {
                listViewThreadCtrl.Items.RemoveAt(20);
            }
        }


        public void Start(string name)
        {
            _shutdownEvent.Reset();
            _thread = new Thread(DoWork);
            _thread.Name = "MyCustThread_" + name;
            _thread.Start();

#if DEBUG
            Debug.WriteLine("Threadas " + Thread.CurrentThread.ManagedThreadId.ToString() + " paleistas.");
#endif
        }

        public void Stop()
        {
            // Signal the shutdown event
            _shutdownEvent.Set();
#if DEBUG
            Debug.WriteLine("Threadas " + "" + " sustabdytas.");
#endif
        }

        void DoWork()
        {
            string[] array = new string[2];
            DMLTools dmlinsert = new DMLTools();
            while (IsCancelled==false)
            {
                int threadid = Thread.CurrentThread.ManagedThreadId;
                array = dmlinsert.InsertINTOAccessTable(threadid.ToString());
 
                if (_shutdownEvent.WaitOne(0))
                    break;

                Random rnd2 = new Random();
                int sleepms = rnd2.Next(1500, 2001);
                Thread.Sleep(sleepms);
                if (IsHandleCreated)
                    listViewThreadCtrl.Invoke(new UpdatelistView(UpdateUI), array[0], array[1]);
                else
                    Stop();
#if DEBUG
                Debug.WriteLine("Thread Id=" + threadid + "is running." + array[0] + ":" + array[1]);
#endif

            }
        }
    }
}
