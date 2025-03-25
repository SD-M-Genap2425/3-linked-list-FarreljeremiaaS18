using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }

        public Karyawan(string nomor, string nama, string posisi)
        {
            NomorKaryawan = nomor;
            Nama = nama;
            Posisi = posisi;
        }
    }

    
    public class KaryawanNode
    {
        public Karyawan Karyawan { get; set; }  
        public KaryawanNode Next { get; set; }
        public KaryawanNode Prev { get; set; }

        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
            Next = null;
            Prev = null;
        }
    }

 
    public class DaftarKaryawan
    {
        private KaryawanNode head;
        private KaryawanNode tail;

        
        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode nodeBaru = new KaryawanNode(karyawan);

            if (head == null)
            {
                head = tail = nodeBaru;
            }
            else
            {
                tail.Next = nodeBaru;
                nodeBaru.Prev = tail;
                tail = nodeBaru;
            }
        }

        
        public bool HapusKaryawan(string nomorKaryawan)
        {
            KaryawanNode temp = head;
            while (temp != null)
            {
                if (temp.Karyawan.NomorKaryawan == nomorKaryawan)
                {
                    if (temp == head)
                        head = head.Next;
                    if (temp == tail)
                        tail = tail.Prev;
                    if (temp.Prev != null)
                        temp.Prev.Next = temp.Next;
                    if (temp.Next != null)
                        temp.Next.Prev = temp.Prev;

                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        
        public Karyawan[] CariKaryawan(string kataKunci)
        {
            List<Karyawan> hasil = new List<Karyawan>();
            KaryawanNode temp = head;

            while (temp != null)
            {
                if (temp.Karyawan.Nama.Contains(kataKunci) || temp.Karyawan.Posisi.Contains(kataKunci))
                    hasil.Add(temp.Karyawan);
                temp = temp.Next;
            }
            return hasil.ToArray();
        }

        
        public string TampilkanDaftar()
        {
            StringBuilder hasil = new StringBuilder();
            KaryawanNode temp = tail;

            while (temp != null)
            {
                hasil.AppendLine($"{temp.Karyawan.NomorKaryawan}; {temp.Karyawan.Nama}; {temp.Karyawan.Posisi}");
                temp = temp.Prev;
            }

            return hasil.ToString().Trim(); 
        }
    }
}
