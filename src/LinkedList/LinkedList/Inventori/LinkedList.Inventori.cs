using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Inventori
{
    public class Item
    {
        public string Nama { get; set; }
        public int Kuantitas { get; set; }

        public Item(string nama, int kuantitas)
        {
            Nama = nama;
            Kuantitas = kuantitas;
        }
    }

    
    public class ManajemenInventori
    {
        private LinkedList<Item> daftarItem = new LinkedList<Item>();

       
        public void TambahItem(Item item)
        {
            daftarItem.AddLast(item);
        }

       
        public bool HapusItem(string nama)
        {
            var node = daftarItem.First;
            while (node != null)
            {
                if (node.Value.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase))
                {
                    daftarItem.Remove(node);
                    return true; 
                }
                node = node.Next;
            }
            return false; 
        }


        public string TampilkanInventori()
        {
            if (daftarItem.Count == 0) return string.Empty;

            List<string> hasil = new List<string>();
            foreach (var item in daftarItem)
            {
                hasil.Add($"{item.Nama}; {item.Kuantitas}");
            }
            return string.Join(Environment.NewLine, hasil); 
        }
    }
}
