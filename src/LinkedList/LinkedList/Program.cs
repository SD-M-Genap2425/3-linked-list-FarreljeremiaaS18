using LinkedList.Inventori;
using LinkedList.ManajemenKaryawan;
using LinkedList.Perpustakaan;

namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {

        KoleksiPerpustakaan perpustakaan = new KoleksiPerpustakaan();

        perpustakaan.TambahBuku(new Buku("The Hobbit", "J.R.R. Tolkien", 1937));
        perpustakaan.TambahBuku(new Buku("1984", "George Orwell", 1949));
        perpustakaan.TambahBuku(new Buku("The Catcher in the Rye", "J.D. Salinger", 1951));

        Console.WriteLine("Daftar Buku di Perpustakaan:");
        Console.WriteLine(perpustakaan.TampilkanKoleksi());

        Console.WriteLine("\nMencari buku dengan kata kunci '1984':");
        Buku[] hasil = perpustakaan.CariBuku("1984");
        foreach (var buku in hasil)
        {
            Console.WriteLine($"Ditemukan: {buku.Judul} oleh {buku.Penulis}");
        }

        Console.WriteLine("\nMenghapus buku '1984'...");
        bool hapusBerhasil = perpustakaan.HapusBuku("1984");
        Console.WriteLine(hapusBerhasil ? "Buku berhasil dihapus." : "Buku tidak ditemukan.");

        Console.WriteLine("\nDaftar Buku setelah penghapusan:");
        Console.WriteLine(perpustakaan.TampilkanKoleksi());


        // Soal ManajemenKaryawan
       
        DaftarKaryawan daftar = new DaftarKaryawan();

        
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        daftar.TambahKaryawan(new Karyawan("002", "Jane Doe", "HR"));
        daftar.TambahKaryawan(new Karyawan("003", "Bob Smith", "IT"));

        Console.WriteLine("Daftar Karyawan (Terbalik):");
        Console.WriteLine(daftar.TampilkanDaftar());

        
        Console.WriteLine("\nMencari Karyawan dengan kata kunci 'Doe':");
        var hasilCari = daftar.CariKaryawan("Doe");
        foreach (var karyawan in hasilCari)
        {
            Console.WriteLine($"{karyawan.NomorKaryawan}; {karyawan.Nama}; {karyawan.Posisi}");
        }

       
        Console.WriteLine("\nMenghapus Karyawan 002...");
        bool hapus = daftar.HapusKaryawan("002");
        Console.WriteLine($"Penghapusan Berhasil: {hapus}");

        Console.WriteLine("\nDaftar Karyawan Setelah Penghapusan:");
        Console.WriteLine(daftar.TampilkanDaftar());


        // Soal Inventori
        ManajemenInventori inventori = new ManajemenInventori();

        
        inventori.TambahItem(new Item("Apple", 50));
        inventori.TambahItem(new Item("Orange", 30));
        inventori.TambahItem(new Item("Banana", 20));

        
        Console.WriteLine("Inventori Awal:");
        inventori.TampilkanInventori();

        
        Console.WriteLine("\nMenghapus 'Orange' dari inventori...");
        bool berhasil = inventori.HapusItem("Orange");

        
        Console.WriteLine(berhasil ? "Item berhasil dihapus!" : "Item tidak ditemukan!");

        
        Console.WriteLine("\nInventori Setelah Dihapus:");
        inventori.TampilkanInventori();
    }
}
