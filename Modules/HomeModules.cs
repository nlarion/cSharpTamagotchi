using Nancy;
using Tamagotchi.Objects;
using System.Collections.Generic;

namespace Tamagotchi
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Pet> allPets = Pet.GetAll();
        if (allPets.Count >=0)
        {
          return View["index.cshtml",allPets];
        }
        else
        {
          return View["index.cshtml"];
        }
      };
      Post["/"] = _ => {
        Pet newPet = new Pet(Request.Form["new-pet"]);
        List<Pet> allPets = Pet.GetAll();
        return View["index.cshtml", allPets];
      };
      Post["/time"]= _ =>{
        Pet.TimePass();
        List<Pet> allPets = Pet.GetAll();
        return View["index.cshtml", allPets];
      };
      Get["/pets/{id}"] = parameters => {
        Pet pet = Pet.Find(parameters.id);
        return View["/pet.cshtml", pet];
      };
      Post["/pets/{id}"]= parameters =>{
        Pet pet = Pet.Find(parameters.id);
        Pet.FeedPet(pet);
        return View["pet.cshtml", pet];
      };
    }
  }
}
