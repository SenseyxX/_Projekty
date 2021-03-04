using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Controllers
{
        public class QualitySeeder
        {
                private readonly MagContext _magContext;

                public QualitySeeder(MagContext magContext)
                {
                        this._magContext = magContext;
                }
                public void Seed()
                {
                        if (_magContext.Database.CanConnect())
                        {
                                if (!_magContext.qualities.Any())
                                {
                                        var qualities = GetQualities();
                                        _magContext.qualities.AddRange(qualities);
                                        _magContext.SaveChangesAsync();
                                }
                        }
                }

                private IEnumerable<Quality> GetQualities()
                {
                        var qualities = new List<Quality>()
                        {
                                        new Quality()
                                        {
                                                QualityNumber = 1,
                                                Description = "Niezanany",
                                        },

                                        new Quality()
                                        {
                                                QualityNumber = 2,
                                                Description = "Bardzo Zły",
                                        },

                                        new Quality()
                                        {
                                                QualityNumber = 3,
                                                Description = "Zły"
                                        },

                                        new Quality()
                                        {
                                                QualityNumber = 4,
                                                Description = "Umiarkowany"
                                        },

                                        new Quality()
                                        {
                                                QualityNumber = 5,
                                                Description = "Dobry"
                                        },

                                        new Quality()
                                        {
                                                QualityNumber = 6,
                                                Description = "Bardzo Dobry"
                                        },

                                        new Quality()
                                        {
                                                QualityNumber = 7,
                                                Description = "Nowy"
                                        }

                        };
                        return qualities;
                }
                
        };
                
                
}

