using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBBill
{
    public class BillDetails
    {
        private int _meterID=1000;

        public string MeterID { get;}
        public string Username { get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public int Unit { get; set; }
        

        public BillDetails(){
            _meterID++;
            MeterID="EB"+_meterID;
        }

        public int CalculateAmount(int unit){
            Unit=unit;
           return Unit*5;
            
        }

    }
}