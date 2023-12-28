using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppQuanly
{
    internal class trahang1
    {
        private string sopt;
        private DateTime ngaytra;
        private string httt;
        private string manv;
        private string mancc;

        public trahang1()
        {
        }

        public trahang1(string sopt, DateTime ngaytra, string httt, string manv, string mancc)
        {
            this.sopt = sopt;
            this.ngaytra = ngaytra;
            this.httt = httt;
            this.manv = manv;
            this.mancc = mancc;
        }

        public string Sopt { get => sopt; set => sopt = value; }
        public DateTime Ngaytra { get => ngaytra; set => ngaytra = value; }
        public string Httt { get => httt; set => httt = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Mancc { get => mancc; set => mancc = value; }
    }
}
