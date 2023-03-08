using DirectoryExplorer.Models;

namespace DirectoryExplorer.Data
{
    public class DataInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();

                context.Database.EnsureCreated();

                var rootDirectory = context.Directories.FirstOrDefault(c => c.ParentDirectoryId == null);
                if (rootDirectory == null)
                {
                    
                    rootDirectory = new DirectoryModel { Name = "Creating Digital Images" };
                    context.Directories.Add(rootDirectory);
                    context.SaveChanges();
                }

                
                if (!context.Directories.Any(c => c.ParentDirectoryId == rootDirectory.Id))
                {
                    var resourcesDirectory = new DirectoryModel { Name = "Resources", ParentDirectoryId = rootDirectory.Id };
                    var evidenceDirectory = new DirectoryModel { Name = "Evidence", ParentDirectoryId = rootDirectory.Id };
                    var graphicProductsDirectory = new DirectoryModel { Name = "Graphic Products", ParentDirectoryId = rootDirectory.Id };


                    context.Directories.AddRange(new List<DirectoryModel>()
                    {
                        resourcesDirectory,
                        evidenceDirectory,
                        graphicProductsDirectory,
                    });
                    context.SaveChanges();

                    if (!context.Directories.Any(c => c.ParentDirectoryId == resourcesDirectory.Id))
                    {
                        var primarySourcesDirectory = new DirectoryModel { Name = "Primary Sources", ParentDirectoryId = resourcesDirectory.Id };
                        var secondarySourcesDirectory = new DirectoryModel { Name = "Secondary Sources", ParentDirectoryId = resourcesDirectory.Id };

                        context.Directories.AddRange(new List<DirectoryModel>()
                        {
                            primarySourcesDirectory,
                            secondarySourcesDirectory,
                        });
                        context.SaveChanges();
                    }

                    if (!context.Directories.Any(c => c.ParentDirectoryId == graphicProductsDirectory.Id))
                    {
                        var processDirectory = new DirectoryModel { Name = "Process", ParentDirectoryId = graphicProductsDirectory.Id };
                        var finalProductDirectory = new DirectoryModel { Name = "Final Product", ParentDirectoryId = graphicProductsDirectory.Id };

                        context.Directories.AddRange(new List<DirectoryModel>()
                        {
                            processDirectory,
                            finalProductDirectory
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
