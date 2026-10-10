using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace hello_world.hinh
{
    public class hinhchunhat
    {
        private double dai;
        public double chieu rong { get; set; }
        [Range(0, double.MaxValue,
ErrorMessage = " chieu rong phai lon hon bang 0")]
        public double chieudai
        {
            get { return dai; }
            set 
            {if (dai < 0)
                    dai = value;
                else
                    throw new Exception("chieu dai khong duoc am");
        }
    }
        public double getdientich()
        {
            try
            {
                return chieudai * chieurong;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.message);
            }
}
