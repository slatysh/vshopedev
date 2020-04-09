using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vshope.Common;
using Vshope.Model.Model.Auth;
using Vshope.Model.Model.Common;
using Vshope.Model.Model.Dict;
using Vshope.Model.Model.Main;

namespace Vshope.Db.Common
{
    public class ContextApp : DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<VkImage> VkImages { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductGoodsType> ProductGoodsTypes { get; set; }
        public DbSet<ProductApparel> ProductApparels { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductAdType> ProductAdTypes { get; set; }
        public DbSet<ProductCondition> ProductConditions { get; set; }

        private void AddTimestamps()
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(x => x.Entity is EntityApp && x.State == EntityState.Added);
            var modifiedEntities = ChangeTracker.Entries()
                .Where(x => x.Entity is EntityApp && x.State == EntityState.Modified);

            var utcNow = DateTimeOffset.UtcNow;
            foreach (var entity in addedEntities)
            {
                var entityApp = (EntityApp)entity.Entity;
                entityApp.CreatedDate = utcNow;
                entityApp.ModifiedDate = utcNow;
            }

            foreach (var entity in modifiedEntities)
            {
                var entityApp = (EntityApp)entity.Entity;
                entityApp.ModifiedDate = utcNow;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = UserRoleNames.ADMIN
                },
                new Role
                {
                    Id = 2,
                    Name = UserRoleNames.USER
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    Email = "admin",
                    PasswordHash = "1WQsxoDVnpZqyS548nWhdA53TNno/tsuCg6X5Sw5POPN7MnQ",
                    RoleId = 1,
                    StatusId = (int)UserStatusEnum.Confirmed
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    UserName = "+79374326040",
                    Email = "oksana",
                    PasswordHash = "B1QrZf+hIErc18k3AvgCW2mmVWQ+Py/Ojys/YqG9fxPu7rbt",
                    RoleId = 2,
                    StatusId = (int)UserStatusEnum.Confirmed
                }
            );

            modelBuilder.Entity<Product>()
                .HasIndex(x => new { x.VkId })
                .IsUnique(true);

            modelBuilder.Entity<VkImage>()
                .HasIndex(x => new { x.VkId })
                .IsUnique(true);

            modelBuilder.Entity<UserStatus>().HasData(
                Enum.GetValues(typeof(UserStatusEnum)).Cast<UserStatusEnum>().Select(x => new UserStatus()
                {
                    Id = (int)x,
                    Name = UserStatusEnumHelper.ToString(x)
                })
            );

            modelBuilder.Entity<ProductType>().HasData(
                Enum.GetValues(typeof(ProductTypeEnum)).Cast<ProductTypeEnum>().Select(x => new ProductType()
                {
                    Id = (int)x,
                    Name = ProductTypeEnumHelper.ToString(x)
                })
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                Enum.GetValues(typeof(ProductCategoryEnum)).Cast<ProductCategoryEnum>().Select(x => new ProductCategory()
                {
                    Id = (int)x,
                    Name = ProductCategoryEnumHelper.ToString(x),
                    TypeId = ProductCategoryEnumHelper.GetTypeId(x)
                })
            );

            modelBuilder.Entity<ProductGoodsType>().HasData(
                Enum.GetValues(typeof(ProductGoodsTypeEnum)).Cast<ProductGoodsTypeEnum>().Select(x => new ProductGoodsType()
                {
                    Id = (int)x,
                    Name = ProductGoodsTypeEnumHelper.ToString(x),
                    CategoryId = ProductGoodsTypeEnumHelper.GetCategoryId(x)
                })
            );

           modelBuilder.Entity<ProductApparel>().HasData(
                Enum.GetValues(typeof(ProductApparelEnum)).Cast<ProductApparelEnum>().Select(x => new ProductApparel()
                {
                    Id = (int)x,
                    Name = ProductApparelEnumHelper.ToString(x),
                    GoodsTypeId = ProductApparelEnumHelper.GetGoodsTypeId(x)
                })
            );

            modelBuilder.Entity<ProductSize>().HasData(
                Enum.GetValues(typeof(ProductSizeEnum)).Cast<ProductSizeEnum>().Select(x => new ProductSize()
                {
                    Id = (int)x,
                    Name = ProductSizeEnumHelper.ToString(x),
                    GoodsTypeId = ProductSizeEnumHelper.GetGoodsTypeId(x),
                    ApparelId = ProductSizeEnumHelper.GetApparelId(x)
                })
            );

           modelBuilder.Entity<ProductAdType>().HasData(
                Enum.GetValues(typeof(ProductAdTypeEnum)).Cast<ProductAdTypeEnum>().Select(x => new ProductAdType()
                {
                    Id = (int)x,
                    Name = ProductAdTypeEnumHelper.ToString(x)
                })
            );

            modelBuilder.Entity<ProductCondition>().HasData(
                Enum.GetValues(typeof(ProductConditionEnum)).Cast<ProductConditionEnum>().Select(x => new ProductCondition()
                {
                    Id = (int)x,
                    Name = ProductConditionEnumHelper.ToString(x)
                })
            );

        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public void SetValuesApp(EntityApp objFromDb, EntityApp obj)
        {
            obj.Id = objFromDb.Id;
            obj.CreatedDate = objFromDb.CreatedDate;
            Entry(objFromDb).CurrentValues.SetValues(obj);
        }
    }
}
