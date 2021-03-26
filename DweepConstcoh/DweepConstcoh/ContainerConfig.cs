using Autofac;
using DweepConstcoh.Game;
using DweepConstcoh.Game.Entities;
using DweepConstcoh.Game.MapStructure;
using DweepConstcoh.Game.Processors;
using DweepConstcoh.Game.Processors.DrawProcess;
using DweepConstcoh.Game.Processors.DrawProcess.Map;
using DweepConstcoh.Game.Processors.DrawProcess.Tools;
using DweepConstcoh.Game.Processors.TaskProcess;
using DweepConstcoh.Game.Tools;

namespace DweepConstcoh
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EntityFactory>().As<IEntityFactory>().InstancePerLifetimeScope();
            builder.RegisterType<Map>().As<IMap>().InstancePerLifetimeScope();
            builder.RegisterType<Toolset>().As<IToolset>().InstancePerLifetimeScope();
            builder.RegisterType<GameState>().As<IGameState>().InstancePerLifetimeScope();
            builder.RegisterType<Game.Game>().As<IGame>().InstancePerLifetimeScope();

            builder.RegisterType<DrawMapProcessor>().As<IDrawMapProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<DrawToolsetProcessor>().As<IDrawToolsetProcessor>().InstancePerLifetimeScope();
            builder.RegisterType<DrawSettings>().As<IDrawSettings>().InstancePerLifetimeScope();
            builder.RegisterType<TaskProcessor>().As<ITaskProcessor>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
