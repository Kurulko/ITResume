using ITResume.Server.Settings;
using ITResume.Shared.Models.Database.ITResumeModels;
using Octokit;

namespace ITResume.Server.Initializers.ITResumeInitializers;

public class TechnologiesInitializer
{
    public static IEnumerable<Technology> GetSomeTechnologies()
        => frameworks.Select(f => new Technology() { Name = f });

    static string[] frameworks =
    {
        "Angular",
        "ASP.NET Core",
        "ASP.NET Core MVC",
        "ASP.NET Core Razor Pages",
        "ASP.NET Core Blazor",
        "MAUI",
        "React",
        "Vue.js",
        "Ember.js",
        "Node.js",
        "Express.js",
        "Django",
        "Flask",
        "Ruby on Rails",
        "Laravel",
        "Symfony",
        "Spring Boot",
        "Hibernate",
        "Flutter",
        "Xamarin",
        "Unity",
        "Cocos2d",
        "Ionic",
        "Electron",
        "TensorFlow",
        "PyTorch",
        "Keras",
        "Vue.js",
        "Backbone.js",
        "Meteor",
        "Polymer",
        "Knockout.js",
        "jQuery",
        "Bootstrap",
        "Foundation",
        "Semantic UI",
        "Bulma",
        "Material-UI",
        "Tailwind CSS",
        "Gatsby",
        "Next.js",
        "Svelte",
        "NestJS",
        "FastAPI",
        "Quarkus",
        "JHipster",
        "Play Framework",
        "Apache Struts",
        "Ember.js",
        "Aurelia",
        "Mithril",
        "Marko",
        "CherryPy",
        "Pyramid",
        "Zend Framework",
        "CakePHP",
        "CodeIgniter",
        "FuelPHP",
        "Phalcon",
        "Yii",
        "Slim",
        "Grails",
        "Seaside",
        "Vaadin",
        "Griffon",
        "Tornado",
        "CherryPy",
        "TurboGears",
        "Web2py"
    };
}
