﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop2018.Models
{
    public enum StanjeProizvoda
    {
        NaStanju,
        Akcija,
        Rasprodato
    }

    public class Proizvod
    {
        public int Id { get; set; }

        public StanjeProizvoda Stanje { get; set; }

        [Required(ErrorMessage = "Naziv mora da se navede")]
        [StringLength(50)]
        [DisplayName("Ime")]
        public string Naziv { get; set; }

        [DisplayName("Vrednost proizvoda")]
        [Range(0.00, 10000.00)]
        public decimal Cena { get; set; }

        public string ImeSlike { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public string ImeSlikeZaPrikaz
        {
            get
            {
                // nije bas najpametnije resenje
                //return string.IsNullOrWhiteSpace(ImeSlike) ? "no_image.png" : string.Format("{0}{1}", Id, ImeSlike);
                // string.Format("~/Content/GalerijaFolder/{0}{1}", proizvodSlika.Id, picture.FileName)
                return Pictures.Count() == 0 ? "no_image.png" : Pictures.FirstOrDefault().Naziv; 
            }
        }


        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Dobavljac> Dobavljaci { get; set; }
       
    }
}