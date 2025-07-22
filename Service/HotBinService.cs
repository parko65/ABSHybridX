﻿using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;
internal sealed class HotBinService : IHotBinService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public HotBinService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HotBinDto>> GetHotBinsAsync(bool trackChanges)
    {
        var hotBins = await _repository.HotBin.GetHotBinsAsync(trackChanges);

        var hotBinDtos = _mapper.Map<IEnumerable<HotBinDto>>(hotBins);

        return hotBinDtos;
    }
}