﻿global using System.ComponentModel.DataAnnotations;
global using System.Net;
global using System.Text.Json;
global using System.Reflection;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity;
global using MediatR;
global using AutoMapper;
global using Serilog;
global using Serilog.Events;
global using CadastralApplication;
global using CadastralApplication.Common.Mappings;
global using CadastralApplication.Interfaces;
global using CadastralApplication.Common.Exceptions;
global using CadastralApplication.Documents.Commands.CreateDocument;
global using CadastralApplication.Documents.Commands.UpdateDocument;
global using CadastralApplication.Documents.Commands.DeleteDocument;
global using CadastralApplication.Documents.Queries.GetDocument;
global using CadastralApplication.Documents.Queries.GetDocumentList;
global using CadastralPersistence;
global using CadastralWebApp.Extensions;
global using CadastralWebApp.Middleware;
global using CadastralWebApp.DTO;
global using CadastralWebApp.Services;