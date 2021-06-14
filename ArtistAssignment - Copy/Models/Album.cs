using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtistAssignment.Models
{
    public class Album
    {
        //the primary key 
        public int ID { get; set; }

        [Required(ErrorMessage ="Title is required")]
        [StringLength(60,MinimumLength =3)]
        [Display(Name ="Album Title")]
        public  string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // Navigation properties hold other entities that are related to this entity
        //.................................................
        //If a navigation property can hold multiple entities
        //(as in many-to-many or one-to-many relationships), its type must be a list
        //in which entries can be added, deleted, and updated, such as ICollection.
        public ICollection<Song> Songs { get; set; }

        //a foreign key
        //Annotation
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}