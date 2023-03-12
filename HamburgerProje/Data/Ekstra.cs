﻿namespace HamburgerProje.Data
{
    public class Ekstra
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public double Fiyat { get; set; }

        public ICollection<EkstraMenu> EkstraMenuler { get; set; }
        public List<Siparis> Siparisler { get; set; } = new();
        public string? Resim { get; set; } = null!;


    }
}
