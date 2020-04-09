using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vshope.Application.Main.Abstr;
using Vshope.Db;
using Vshope.Db.Common;
using Vshope.Model.DTO.Main;
using Vshope.Model.Model.Main;

namespace Vshope.Application.Main
{
    public class AvitoXmlService: IAvitoXmlService
    {
        private readonly ContextApp _context;
        private readonly IMapper _mapper;

        public AvitoXmlService(ContextApp context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public async Task<Stream> DownloadXml(AvitoXmlDownloadRequestDTO dto, int companyId)
        {
            var productList = await _context.Products.WhereIsNotDeleted(x=> x.CompanyId == companyId).Include(x=> x.Images).ToListAsync();
            /*
                <Ads formatVersion="3" target="Avito.ru">
                  <Ad>
                       <Id>723681273</Id>
                       <DateBegin>2015-11-27</DateBegin>
                       <DateEnd>2079-08-28</DateEnd>
                       <AdStatus>TurboSale</AdStatus>
                       <AllowEmail>Да</AllowEmail>
                       <ManagerName>Иван Петров-Водкин</ManagerName>
                       <ContactPhone>+7 916 683-78-22</ContactPhone>
                       <Region>Владимирская область</Region>
                       <City>Владимир</City>
                       <District>Ленинский</District>
                       <Category>Одежда, обувь, аксессуары</Category>
                       <GoodsType>Женская одежда</GoodsType> 
                       <AdType>Товар приобретен на продажу</AdType>
                       <Apparel>Платья и юбки</Apparel>
                       <Size>S</Size>
                       <Title>Прекрасное платье</Title>
                     <Description><![CDATA[
               <p>Лёгкая и изящная юбка, не сковывает движения откроет ваши стройные гибкие ноги. На сцене такая юбка смотрится невероятно красиво и прелестно, она словно выступает неотъемлемым элементом происходящего там действия. Идеально подходит для вечера, корпоратива или же для повседневной жизни.</p>
               <p>Сделана из тонких полупрозрачных тканей:</p>
               <ul>
               <li>шифона</li>
               <li>фатина</li>
               <li>сетки</li>
               </ul>
               ]]></Description>
                       <Price>25300</Price>
                       <Images>
                           <Image url="http://img.test.ru/8F7B-4A4F3A0F2BA1.jpg" />
                           <Image url="http://img.test.ru/8F7B-4A4F3A0F2XA3.jpg" />
                       </Images>
                       <VideoURL>http://www.youtube.com/watch?v=YKmDXNrDdBI</VideoURL>
                   </Ad>
               </Ads>
                */

            List<XElement> productElements = new List<XElement>();
            foreach (var product in productList)
            {
                var productImagesSorted = product.Images.OrderBy(x => x.VkId);
                var imageElements = new List<XElement>();
                foreach (var image in productImagesSorted)
                {
                    imageElements.Add(new XElement("Image",
                        new XAttribute("url", image.Url)));
                }

                var descriptionFull = product.Description;
                if (!string.IsNullOrEmpty(dto.ProductAdditionalDesc))
                {
                    if (!string.IsNullOrEmpty(descriptionFull))
                    {
                        descriptionFull += "\n\n";
                    }
                    descriptionFull += dto.ProductAdditionalDesc;
                }

                XElement productEl = new XElement("Ad",
                    new XElement("Id", product.Id),
                    new XElement("DateBegin", dto.DateStart),
                    new XElement("DateEnd", dto.DateFinish),
                    new XElement("ManagerName", dto.ManagerName),
                    new XElement("ContactPhone", dto.ContactPhone),
                    new XElement("Address", dto.Address),
                    new XElement("Title", product.Name),
                    new XElement("Description", descriptionFull),
                    new XElement("Price", product.Price),
                    new XElement("Images", imageElements));

                var category = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == dto.ProductCategoryId);
                var goodsType = await _context.ProductGoodsTypes.FirstOrDefaultAsync(x => x.Id == dto.ProductGoodsTypeId);
                var adType = await _context.ProductAdTypes.FirstOrDefaultAsync(x => x.Id == dto.ProductAdTypeId);
                var apparel = await _context.ProductApparels.FirstOrDefaultAsync(x => x.Id == dto.ProductApparelId);
                var size = await _context.ProductSizes.FirstOrDefaultAsync(x => x.Id == dto.ProductSizeId);
                var condition = await _context.ProductConditions.FirstOrDefaultAsync(x => x.Id == dto.ProductConditionId);
                if (category != null)
                {
                    productEl.Add(new XElement("Category", category.Name));
                }
                if (goodsType != null)
                {
                    productEl.Add(new XElement("GoodsType", goodsType.Name));
                }
                if (adType != null)
                {
                    productEl.Add(new XElement("AdType", adType.Name));
                }
                if (apparel != null)
                {
                    productEl.Add(new XElement("Apparel", apparel.Name));
                }
                if (size != null)
                {
                    productEl.Add(new XElement("Size", size.Name));
                }
                if (condition != null)
                {
                    productEl.Add(new XElement("Condition", condition.Name));
                }
                productElements.Add(productEl);
            }
            XElement main = new XElement("Ads",
                new XAttribute("formatVersion", "3"),
                new XAttribute("target", "Avito.ru"),
                productElements);
            XDocument avitoDoc = new XDocument(main);
            MemoryStream ms = new MemoryStream();
            avitoDoc.Save(ms);
            ms.Position = 0;
            return ms;
        }
        

    }
}
