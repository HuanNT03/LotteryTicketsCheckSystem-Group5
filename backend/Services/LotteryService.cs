using LotteryBackend.Models;
using LotteryBackend.Repositories;

namespace LotteryBackend.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly ILotteryResultRepository _lotteryResultRepository;

        public LotteryService(ILotteryResultRepository lotteryResultRepository)
        {
            _lotteryResultRepository = lotteryResultRepository;
        }

        public async Task<LotteryResult?> GetResultByDateAsync(DateTime date)
        {
            return await _lotteryResultRepository.GetResultByDateAsync(date);
        }

        public async Task AddResultAsync(LotteryResult result)
        {
            await _lotteryResultRepository.AddResultAsync(result);
        }

        public async Task<IEnumerable<LotteryResult>> GetAllResultsAsync()
        {
            return await _lotteryResultRepository.GetAllResultsAsync();
        }

        public async Task UpdateResultAsync(LotteryResult result)
        {
            await _lotteryResultRepository.UpdateResultAsync(result);
        }

        public async Task DeleteResultAsync(int resultId)
        {
            await _lotteryResultRepository.DeleteResultAsync(resultId);
        }
    }
}
