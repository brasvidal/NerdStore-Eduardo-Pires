﻿using NerdStore.Core.Domain.DomainObjects;

namespace NerdStore.Catalogo.Domain;

public class Produto : Entity, IAgregateRoot
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public bool Ativo { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public string Imagem { get; private set; }
    public decimal QuantidadeEstoque { get; private set; }
    public Categoria      Categoria { get; private set; }
    public Guid CategoriaId { get; private set; }

    public Produto(string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, Guid categoriaId)
    {
        CategoriaId = categoriaId;
        Nome = nome;
        Descricao = descricao;
        Ativo = ativo;
        Valor = valor;
        DataCadastro = dataCadastro;
        Imagem = imagem;
 
    }

    public void Ativar() => Ativo = true;
    public void Desativar() => Ativo = false;

    public void AlterarCategoria(Categoria categoria)
    {
        Categoria = categoria;
        CategoriaId = categoria.Id;
    }

    public void AlterarDescricao(string descricao)
    {
        Descricao = descricao;
    }

    public void DebitarEstoque(decimal quantidade)
    {
        if (quantidade < 0) quantidade *= -1;
        QuantidadeEstoque -= quantidade;
    }

    public void ReporEstoque(decimal quantidade)
    {
        QuantidadeEstoque += quantidade;
    }

    public bool PossuiEstoque(decimal quantidade)
    {
        return QuantidadeEstoque >= quantidade;
    }

    public void Validar()
    {
        
    }
}

public class Categoria : Entity
{
    public string Nome { get; private set; }
    public int Codigo { get; private set; }

    public Categoria(string nome, int codigo)
    {
        Nome = nome;
        Codigo = codigo;    
    }

    public override string ToString()
    {
        return $"{Nome} - {Codigo}";
    }
}