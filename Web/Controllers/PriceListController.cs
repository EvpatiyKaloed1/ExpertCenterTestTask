using Application.Commands;
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

    [HttpGet("create-price-list")]
    public IActionResult CreatePriceListStart()
    {
        var model = new CreatePriceListViewModel();
        return View(model);
    }

    [HttpPost("create-price-list")]
    public async Task<IActionResult> CreatePriceListEnd([FromForm] CreatePriceListViewModel createDto)
    {
        var priceList = await _sender.Send(new CreatePriceListCommand(createDto.PriceListName, createDto.PriceListNumber, createDto.ProductName, createDto.ProductCode,
             createDto.Columns.Select(x => new Column(x.Number,
                                                      x.Header,
                                                      new NumberType(x.NumberAsBool(), x.NumberValues),
                                                      new StringType(x.StringAsBool(), x.StringValues),
                                                      new TextType(x.TextAsBool(), x.TextValues))).ToList()));

        return RedirectToAction(nameof(Index));
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
            Header = priceList.Name,
            Number = priceList.Number,
            Columns = priceList.Columns.Select(x => new ColumnViewModel
            {
                Header = x.Header,
                Number = x.Number,
                IsNumber = x.NumberType.IsExist == true ? "on" : "off",
                IsString = x.StringType.IsExist == true ? "on" : "off",
                IsText = x.TextType.IsExist == true ? "on" : "off",
                NumberValues = x.NumberType.Value,
                StringValues = x.StringType.Value,
                TextValues = x.TextType.Value,
            }).ToList()
        });
    }

    public IActionResult Index()
    {
        return View();
    }
}