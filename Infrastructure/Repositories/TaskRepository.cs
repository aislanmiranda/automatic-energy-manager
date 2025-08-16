using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
            => _context = context;

        public async Task<List<ScheduleTask>> InsertRangeAsync(List<ScheduleTask> tasks,
            CancellationToken cancellationToken)
        {
            _context.Set<ScheduleTask>().AddRange(tasks);

            await _context.SaveChangesAsync(cancellationToken);

            return tasks;
        }

        public async Task<List<ScheduleTask>> InsertOrUpdateRangeAsync(
            List<ScheduleTask> tasks,
            CancellationToken cancellationToken)
        {
            // Cria uma lista de tuplas com Expression e Action
            var keys = tasks
                .Select(e => (e.Expression, e.Action, e.EquipamentId))
                .ToList();

            // Consulta apenas as tarefas que já existem com mesma Expression e Action
            var existingTasks = _context.Set<ScheduleTask>()
                .AsNoTracking()
                .AsEnumerable() // força avaliação no cliente
                .Where(p => keys.Any(k =>
                    k.Expression == p.Expression &&
                    k.Action == p.Action &&
                    k.EquipamentId == p.EquipamentId))
                .ToList();

            foreach (var newTask in tasks)
            {
                var existing = existingTasks.FirstOrDefault(p =>
                    p.Expression == newTask.Expression &&
                    p.Action == newTask.Action);

                if (existing is null)
                    _context.Set<ScheduleTask>().Add(newTask);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return tasks;
        }

        public async Task<List<ScheduleTask>> UpdateRangeAsync(List<ScheduleTask> tasks,
            CancellationToken cancellationToken)
        {
            _context.Set<ScheduleTask>().UpdateRange(tasks);

            await _context.SaveChangesAsync(cancellationToken);

            return tasks;
        }

        public async Task<ScheduleTask> UpdateAsync(ScheduleTask entity, CancellationToken cancellationToken)
        {
            var model = _context.Update(entity).Entity;
            await _context.SaveChangesAsync(cancellationToken);
            return model;
        }

        public async Task<ScheduleTask> DeleteByTaskIdAsync(string taskJobId, Guid equipamentId, CancellationToken cancellationToken)
        {
            var entity = await _context
                .Set<ScheduleTask>()
                .FirstOrDefaultAsync(p => p.TaskJobId == taskJobId
                    && p.EquipamentId == equipamentId, cancellationToken);

            if (entity == null)
                throw new Exception("Entity not found");

            _context.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<List<ScheduleTask>?> GetAll(Guid equipamentId,
            CancellationToken cancellationToken)
        {
            var list = await _context
                                .Set<ScheduleTask>()
                                .Where(c => c.EquipamentId == equipamentId)
                                .ToListAsync(cancellationToken);
            return list;
        }

        public async Task<bool> Exists(string key,
            CancellationToken cancellationToken)
            => await _context
                    .Set<ScheduleTask>()
                    .AnyAsync(c => c.Expression.Equals(key), cancellationToken);            
    }
}

