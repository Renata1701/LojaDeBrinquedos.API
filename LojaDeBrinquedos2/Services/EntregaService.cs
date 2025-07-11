﻿namespace LojaDeBrinquedos2.Services;

public class EntregaService
{
    public IEnumerable<EntregaService> GetAll() => _entregas;

    public EntregaService GetById(int id)
    {
        return _entregas.FirstOrDefault(e => e.Id == id);
    }

    public EntregaService Create(EntregaService entrega)
    {
        entrega.Id = _entregas.Count + 1;
        _entregas.Add(entrega);
        return entrega;
    }

    public EntregaService Update(int id, EntregaService entrega)
    {
        var existing = _entregas.FirstOrDefault(e => e.Id == id);
        if (existing == null) return null;

        existing.PedidoId = entrega.PedidoId;
        existing.TransportadoraId = entrega.TransportadoraId;
        existing.Status = entrega.Status;
        existing.CodigoRastreio = entrega.CodigoRastreio;
        existing.DataEnvio = entrega.DataEnvio;
        existing.DataEntregaPrevista = entrega.DataEntregaPrevista;
        existing.DataEntregaReal = entrega.DataEntregaReal;

        return existing;
    }
    public bool Delete(int id)
    {
        var entrega = _entregas.FirstOrDefault(e => e.Id == id);
        if (entrega == null) return false;
        _entregas.Remove(entrega);
        return true;
    }
}





