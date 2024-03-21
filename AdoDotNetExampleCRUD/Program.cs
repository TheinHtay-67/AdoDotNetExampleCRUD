// See https://aka.ms/new-console-template for more information
using AdoDotNetExampleCRUD.AdoDotNetExamples;

Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(1);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Create("test title1", "test author1", "test content1");
//adoDotNetExample.Create(author: "test author2", title: "test title2", content: "test content2"); // can pass parameter as like this if the parameter not sequence
//adoDotNetExample.Update(5, "test title update1", "test author update1", "test content update1");
adoDotNetExample.Delete(4);

Console.ReadKey();