﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace HttpReports.Dashboard.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        private readonly ICapPublisher _capBus;
        public TestController(ICapPublisher capPublisher)
        { 
            _capBus = capPublisher;
        }


        [HttpGet]
        public async Task<IActionResult> CAPPublish()
        {
            _capBus.Publish("xxx.services.show.time", DateTime.Now);

            return await Task.FromResult(Ok());
        }  

        [CapSubscribe("xxx.services.show.time")]
        public void CheckReceivedMessage(DateTime datetime)
        {
            Console.WriteLine(datetime);
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            System.Threading.Thread.Sleep(new Random().Next(99, 4999));

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://localhost:5010/api/Test/Index1");

                return await Task.FromResult(Ok(result));
            } 
            
        }


        [HttpGet]
        public async Task<IActionResult> Index1()
        {
            System.Threading.Thread.Sleep(new Random().Next(99, 4999));

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://localhost:5010/api/Test/Index2");

                return await Task.FromResult(Ok(result));
            }

        }


        [HttpGet]
        public async Task<IActionResult> Index2()
        {
            System.Threading.Thread.Sleep(new Random().Next(99, 4999));

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://localhost:5010/api/Test/Index3");

                return await Task.FromResult(Ok(result));
            }

        }


        [HttpGet]
        public async Task<IActionResult> Index3()
        {
            System.Threading.Thread.Sleep(new Random().Next(99, 4999));

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://localhost:5010/api/Test/Index4");

                return await Task.FromResult(Ok(result));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Index4()
        {
            System.Threading.Thread.Sleep(new Random().Next(99, 4999));

            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://localhost:5010/api/Test/Index5");

                return await Task.FromResult(Ok(result));
            }

        }

        [HttpGet]
        public async Task<IActionResult> Index5()
        {
            System.Threading.Thread.Sleep(new Random().Next(99, 4999));

            return await Task.FromResult(Ok(new { code = 1,message = "ok"})); 

        } 

    }
}