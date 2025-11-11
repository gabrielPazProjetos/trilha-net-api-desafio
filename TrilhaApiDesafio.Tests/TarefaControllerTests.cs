using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Controllers;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Context;
using Microsoft.EntityFrameworkCore;
using System;

namespace TrilhaApiDesafio.Tests
{
    public class TarefaControllerTests
    {
        private TarefaController GetControllerWithContext()
        {
            var options = new DbContextOptionsBuilder<OrganizadorContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new OrganizadorContext(options);
            return new TarefaController(context);
        }

        [Fact]
        public void Criar_DeveRetornarCreatedAtAction()
        {
            var controller = GetControllerWithContext();
            var tarefa = new Tarefa
            {
                Titulo = "Teste",
                Descricao = "Descrição",
                Data = DateTime.Now,
                Status = EnumStatusTarefa.Pendente
            };

            var resultado = controller.Criar(tarefa);

            Assert.IsType<CreatedAtActionResult>(resultado);
        }

        [Fact]
        public void ObterPorId_TarefaNaoExiste_DeveRetornarNotFound()
        {
            var controller = GetControllerWithContext();
            var resultado = controller.ObterPorId(999);
            Assert.IsType<NotFoundResult>(resultado);
        }
    }
}
