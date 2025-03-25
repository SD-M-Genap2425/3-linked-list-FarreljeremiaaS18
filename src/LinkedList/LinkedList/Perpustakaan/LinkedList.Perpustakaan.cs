using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Perpustakaan
{
    public class Buku
    {
        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int Tahun { get; set; }

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data { get; set; }
        public BukuNode Next { get; set; }

        public BukuNode(Buku buku)
        {
            Data = buku;
            Next = null;
        }
    }

    public class KoleksiPerpustakaan
    {
        private BukuNode head;

        public void TambahBuku(Buku buku)
        {
            BukuNode nodeBaru = new BukuNode(buku);
            if (head == null)
                head = nodeBaru;
            else
            {
                BukuNode temp = head;
                while (temp.Next != null)
                    temp = temp.Next;
                temp.Next = nodeBaru;
            }
        }

        public bool HapusBuku(string judul)
        {
            if (head == null) return false;

            if (head.Data.Judul == judul)
            {
                head = head.Next;
                return true;
            }

            BukuNode temp = head;
            while (temp.Next != null && temp.Next.Data.Judul != judul)
                temp = temp.Next;

            if (temp.Next == null) return false;

            temp.Next = temp.Next.Next;
            return true;
        }

        public Buku[] CariBuku(string kataKunci)
        {
            List<Buku> hasil = new List<Buku>();
            BukuNode temp = head;
            while (temp != null)
            {
                if (temp.Data.Judul.Contains(kataKunci))
                    hasil.Add(temp.Data);
                temp = temp.Next;
            }
            return hasil.ToArray();
        }
        public string TampilkanKoleksi()
        {
            BukuNode temp = head;
            if (temp == null) return string.Empty;

            List<string> output = new List<string>();
            while (temp != null)
            {
                output.Add($"\"{temp.Data.Judul}\"; {temp.Data.Penulis}; {temp.Data.Tahun}");
                temp = temp.Next;
            }
            return string.Join("\n", output);
        }
    }
}
