using System;
using System.Collections.Generic;

class CustomPackageManager
{
    
    static Dictionary<string, string> packageRepository = new Dictionary<string, string>
    {
        { "PackageA", "1.0.0" },
        { "PackageB", "2.1.3" },
        { "PackageC", "0.9.8" }
    };

   
    static Dictionary<string, string> installedPackages = new Dictionary<string, string>();

    static void Main()
    {
        string userInput;

        do
        {
            Console.Clear();
            Console.WriteLine("=== Custom Package Manager ===");
            Console.WriteLine("1. List Available Packages");
            Console.WriteLine("2. Install a Package");
            Console.WriteLine("3. List Installed Packages");
            Console.WriteLine("4. Remove a Package");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    ListAvailablePackages();
                    break;
                case "2":
                    InstallPackage();
                    break;
                case "3":
                    ListInstalledPackages();
                    break;
                case "4":
                    RemovePackage();
                    break;
                case "5":
                    Console.WriteLine("Exiting... Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        } while (userInput != "5");
    }

    static void ListAvailablePackages()
    {
        Console.WriteLine("\nAvailable Packages:");
        foreach (var package in packageRepository)
        {
            Console.WriteLine($"- {package.Key} (v{package.Value})");
        }
        Console.WriteLine("\nPress Enter to continue.");
        Console.ReadLine();
    }

    static void InstallPackage()
    {
        Console.Write("Enter the package name to install: ");
        string packageName = Console.ReadLine();

        if (packageRepository.ContainsKey(packageName))
        {
            if (installedPackages.ContainsKey(packageName))
            {
                Console.WriteLine("Package is already installed.");
            }
            else
            {
                installedPackages[packageName] = packageRepository[packageName];
                Console.WriteLine($"Package {packageName} (v{packageRepository[packageName]}) installed successfully.");
            }
        }
        else
        {
            Console.WriteLine("Package not found in repository.");
        }
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void ListInstalledPackages()
    {
        Console.WriteLine("\nInstalled Packages:");
        if (installedPackages.Count == 0)
        {
            Console.WriteLine("No packages installed.");
        }
        else
        {
            foreach (var package in installedPackages)
            {
                Console.WriteLine($"- {package.Key} (v{package.Value})");
            }
        }
        Console.WriteLine("\nPress Enter to continue.");
        Console.ReadLine();
    }

    static void RemovePackage()
    {
        Console.Write("Enter the package name to remove: ");
        string packageName = Console.ReadLine();

        if (installedPackages.ContainsKey(packageName))
        {
            installedPackages.Remove(packageName);
            Console.WriteLine($"Package {packageName} removed successfully.");
        }
        else
        {
            Console.WriteLine("Package is not installed.");
        }
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
}