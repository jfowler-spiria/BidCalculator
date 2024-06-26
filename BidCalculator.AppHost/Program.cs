var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.BidCalculator_Api>("api");

builder.AddNpmApp("frontend", "../BidCalculator.Frontend")
    .WithReference(api)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
