using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Logic
{
    public class bdLogic
    {
        bdCRUD crud = new bdCRUD();
        bdQueries qry = new bdQueries();

        public void InsertPet(objPet pet)
        {
            crud.insertPet(pet);
        }

        public void UpdatePet(objPet pet)
        {
            crud.updatePet(pet);
        }

        public void InsertPetLikes(int pet_Id)
        {
            crud.insert_PetLikes(pet_Id);
        }

        public void InsertUser(int userId, string name)
        {
            crud.insert_User(userId, name);
        }

        public void InsertAdoption(int owner_Id, string owner_Name, int pet_Id, DateTime adoption_Date)
        {
            crud.insert_Adoption(owner_Id, owner_Name, pet_Id, adoption_Date);
        }

        public void UpdatePetImage(int petId, byte[] imageData)
        {
            crud.updatePetImage(petId, imageData);
        }

        public void LoadPets(DataGridView dgv)
        {
            qry.queryPets(dgv);
        }

        public void LoadSizes(DataGridView dgv)
        {
            qry.load_Sizes(dgv);
        }

        public void LoadColors(DataGridView dgv)
        {
            qry.load_Colors(dgv);
        }

        public void LoadPetInformation(DataGridView dgv, int id)
        {
            qry.load_PetInformation(dgv, id);
        }

        public string GetPetNameById(int petId)
        {
            return qry.get_NameByPetId(petId);
        }

        public void LoadAdoptedPets(DataGridView dgv)
        {
            qry.get_adoptedPets(dgv);
        }

        public void LoadTop3LikedPets(DataGridView dgv)
        {
            qry.get_Top3Likes(dgv);
        }

       public Image ResizeImage(Image img, int width, int height)
        {
            using (Bitmap resizedBitmap = new Bitmap(img, new Size(width, height)))
            {
                return new Bitmap(resizedBitmap);
            }
        }

    }
}

