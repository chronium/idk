using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Idk.API;

public class StructureDefinition {
   public string Name { get; set; }
   public string Title { get; set; }
   public string Group { get; set; }
   public string Path { get; set; }

   public bool DoUseGroup { get; set; }

   public StructureDefinition(string name, string title, string group, string path, bool doUseGroup = true) {
      Name = name;
      Title = title;
      Group = group;
      Path = path;
      DoUseGroup = doUseGroup;
   }
}

public static class Structure {

   public class TenantApiGroupAttribute : ApiExplorerSettingsAttribute {

      public TenantApiGroupAttribute() => GroupName = TenantV1Group;
   }

   public class ManagerApiGroupAttribute : ApiExplorerSettingsAttribute {

      public ManagerApiGroupAttribute() => GroupName = ManagerV1Group;
   }

   private const string TenantV1Group = "tenant-v1";
   private const string ManagerV1Group = "manager-v1";

   public static readonly StructureDefinition TenantV1 = new("tenant-v1", "Tenant API v1", TenantV1Group, "tenant-v1/swagger.json");
   public static readonly StructureDefinition ManagerV1 = new("manager-v1", "Manager API v1", ManagerV1Group, "manager-v1/swagger.json");
   public static readonly StructureDefinition Unsorted = new("unsorted", "Unsorted", "unsorted", "unsorted/swagger.json", false);

   public static readonly StructureDefinition[] All = new[] { TenantV1, ManagerV1, Unsorted };

   public static bool InclusionPredicate(string name, ApiDescription apiDescription) {
      foreach (var def in All)
         if (name == def.Name && (!def.DoUseGroup || def.Group == apiDescription.GroupName))
            return true;
      return false;
   }
}

public static class SwaggerGenExtensions {

   public static void SwaggerDoc(this SwaggerGenOptions options, StructureDefinition structureDef)
      => options.SwaggerDoc(structureDef.Name, new OpenApiInfo {
         Title = structureDef.Title
      });

   public static void SwaggerEndpoint(this SwaggerUIOptions options, StructureDefinition structureDef)
      => options.SwaggerEndpoint(structureDef.Path, structureDef.Name);
}