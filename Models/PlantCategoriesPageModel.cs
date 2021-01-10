using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Chisu_Diana_Proiect.Data;


namespace Chisu_Diana_Proiect.Models
{
    public class PlantCategoriesPageModel : PageModel

    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Chisu_Diana_ProiectContext context,
        Plant Plant)
        {
            var allCategories = context.Category;
            var PlantCategories = new HashSet<int>(
            Plant.PlantCategories.Select(c => c.PlantID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = PlantCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdatePlantCategories(Chisu_Diana_ProiectContext context,
        string[] selectedCategories, Plant PlantToUpdate)
        {
            if (selectedCategories == null)
            {
                PlantToUpdate.PlantCategories = new List<PlantCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var PlantCategories = new HashSet<int>
            (PlantToUpdate.PlantCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!PlantCategories.Contains(cat.ID))
                    {
                        PlantToUpdate.PlantCategories.Add(
                        new PlantCategory
                        {
                            PlantID = PlantToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (PlantCategories.Contains(cat.ID))
                    {
                        PlantCategory courseToRemove
                        = PlantToUpdate
                        .PlantCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}