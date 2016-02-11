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
      Post["/pets/{id}/food"]= parameters => {
        Pet pet = Pet.Find(parameters.id);
        pet.FeedPet();
        return View["pet.cshtml", pet];
      };
      Post["/pets/{id}/attention"]= parameters => {
        Pet pet = Pet.Find(parameters.id);
        pet.AttentionPet();//increase attention
        return View["pet.cshtml", pet];
      };
      Post["/pets/{id}/rest"]= parameters => {
        Pet pet = Pet.Find(parameters.id);
        pet.RestPet();//increase rest
        return View["pet.cshtml", pet];
      };
      Post["/clear"]= _ => {
        List<Pet> allPets = Pet.GetAll();
        Pet.ClearAll();
        return View["index.cshtml", allPets];
      };
    }
  }
}
