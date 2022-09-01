using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using stateandcapitalapp_api.context;
using stateandcapitalapp_api.repository;

[assembly: FunctionsStartup(typeof(stateandcapitalapp_api.Startup))]

namespace stateandcapitalapp_api
{
    public class Startup: FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            builder.Services.AddDbContext<PortfolioDbContext>();
            builder.Services.AddTransient<ICapitalRepository, CapitalRepository>();
            builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
            builder.Services.AddTransient<IStateRepository, StateRepository>();
            builder.Services.AddTransient<IScoreRepository, ScoreRepository>();
        }
    }
    }

