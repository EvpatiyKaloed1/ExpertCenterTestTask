using Application.Commands;
using Application.Commands.AddProduct;
using Application.Commands.Create;
using Application.Commands.Delete;
using Application.Queries.GetAllPriceLists;
using Application.Queries.GetPriceList;
using Domain;
using Domain.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

[Route("PriceList")]
public class PriceListController : Controller
{
    private readonly ISender _sender;

    public PriceListController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public IActionResult CreatePriceList()
    {
        var model = new CreatePriceListViewModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePriceList([FromForm] CreatePriceListViewModel createDto)
    {
        var priceList = await _sender.Send(new CreatePriceListCommand(createDto.PriceListName, createDto.PriceListNumber, createDto.ProductName, createDto.ProductCode,
             createDto.Columns.Select(x => new Column(
                                                      x.Header,
                                                      new NumberType(x.NumberAsBool(), x.NumberValues),
                                                      new StringType(x.StringAsBool(), x.StringValues),
                                                      new TextType(x.TextAsBool(), x.TextValues))).ToList()));

        return RedirectToAction(nameof(GetAllPriceLists));
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeletePriceList([FromQuery] Guid id)
    {
        await _sender.Send(new DeletePriceListCommand(id));

        return RedirectToAction(nameof(GetAllPriceLists));
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllPriceLists()
    {
        var priceLists = await _sender.Send(new GetAllPriceListsQuery());

        var viewModel = new GetAllPriceListsViewModel
        {
            Items = priceLists.Select(x => new GetAllPriceListsItem
            {
                Name = x.Name,
                Number = x.Number,
                Id = x.Id,
            }).ToList()
        };
        return View(viewModel);
    }

    [HttpGet("get-price-list")]
    public async Task<IActionResult> GetPriceList([FromQuery] Guid Id)
    {
        var priceList = await _sender.Send(new GetPriceListQuery(Id));
        return View(new PriceListViewModel
        {
            PriceListName = priceList.Name,
            PriceListNumber = priceList.Number,
            PriceListId = priceList.Id,
            Columns = priceList.Columns.Select(x => new ColumnViewModel
            {
                Header = x.Header,
                IsNumber = x.NumberType.IsExist == true ? "on" : "off",
                IsString = x.StringType.IsExist == true ? "on" : "off",
                IsText = x.TextType.IsExist == true ? "on" : "off",
                NumberValues = x.NumberType.Value,
                StringValues = x.StringType.Value,
                TextValues = x.TextType.Value,
            }).ToList()
        });
    }

    [HttpGet("add-product")]
    public async Task<IActionResult> AddProduct([FromQuery] Guid id)
    {
        return View(new AddProductViewModel());
    }

    [HttpPost("add-product")]
    public async Task<IActionResult> AddProduct([FromForm] AddProductViewModel addDto, [FromQuery] Guid id)
    {
        await _sender.Send(new AddProductCommand(id, addDto.Columns.Select(x => new Column(x.Header,
                                                                                           new NumberType(x.NumberAsBool(), x.NumberValues),
                                                                                           new StringType(x.StringAsBool(), x.StringValues),
                                                                                           new TextType(x.TextAsBool(), x.TextValues))).ToList(),
                                                                                           addDto.ProductName, 
                                                                                           addDto.ProductCode));

        return RedirectToAction(nameof(GetPriceList), new { id });
    }
}