using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWithThreadsDB
{
    class ThreadData
    {
        private string _threadId;
        private DateTime _threadTime;
        private string _threadData;

        public string threadId
        {
            get
            {
                return this._threadId;
            }
            set
            {
                this._threadId = value;
            }
        }
        public DateTime threadTime
        {
            get
            {
                return this._threadTime;
            }
            set
            {
                this._threadTime = value;
            }
        }
        public string threadData
        {
            get
            {
                return this._threadData;
            }
            set
            {
                this._threadData = value;
            }
        }

        public ThreadData()
        {

        }

        public ThreadData(string threadId, DateTime threadTime, string threadData)
        {
            _threadId = threadId;
            _threadTime = threadTime;
            _threadData = threadData;
        }
    }
}
