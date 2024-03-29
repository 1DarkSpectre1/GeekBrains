﻿
using Less2;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using Xunit;

namespace Lesson2_Tests
{
    public class MicroThreadPool_Tests
    {
        [Fact]
        public void AddTaskToPool_add_null_throw_exception()
        {
            var pool = new MicroThreadPool();

            Type type = typeof(ArgumentNullException);
            Assert.Throws(exceptionType: type, testCode: () => pool.AddTaskToPool(null));
        }

        [Fact]
        public void AddTaskToPool_add_not_null()
        {
            var pool = new MicroThreadPool();
            var task = new Task(CalculateSum);
            var expectedEntry = $"{task.Id} {task.Status}";

            async void CalculateSum()
            {
                int a = 100_000, b = 2_000;
                Debug.WriteLine($"Sum {a + b}");
                await Task.Delay(100);
            }

            pool.AddTaskToPool(task);

            foreach (var actualEntry in pool.GetAllTasksFromPool())
                Assert.Equal(expectedEntry, actualEntry);
        }

        [Fact]
        public void AddTaskToPool_more_than_limit_pool()
        {
            var pool = new MicroThreadPool();

            async void CalculateSum()
            {
                int a = 100_000, b = 2_000;
                Debug.WriteLine($"Sum {a + b}");
                await Task.Delay(100);
            }

            Type type = typeof(ArgumentOutOfRangeException);
            Assert.Throws(exceptionType: type, testCode: () =>
            {
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
                pool.AddTaskToPool(new(CalculateSum));
            });
        }

        [Fact]
        public void RemoveTaskFromPool_delete_by_nonexistent_id()
        {
            var pool = new MicroThreadPool();

            Assert.False(pool.RemoveTaskFromPool(43));
        }

        [Fact]
        public void RemoveTaskFromPool_delete_by_existing_id()
        {
            var pool = new MicroThreadPool();
            var task = new Task(CalculateSum);

            async void CalculateSum()
            {
                int a = 100_000, b = 2_000;
                Debug.WriteLine($"Sum {a + b}");
                await Task.Delay(100);
            }

            pool.AddTaskToPool(task);

            Assert.True(pool.RemoveTaskFromPool(task.Id));
        }

        [Fact]
        public void RemoveTaskFromPool_delete_task_immediately_after_it_start()
        {
            var pool = new MicroThreadPool();
            var task = new Task(CalculateSum);

            async void CalculateSum()
            {
                int a = 100_000, b = 2_000;
                Debug.WriteLine($"Sum {a + b}");
                await Task.Delay(100);
            }

            pool.AddTaskToPool(task);
            pool.StartTaskFromPool(task.Id);

            Assert.True(pool.RemoveTaskFromPool(task.Id));
        }

        [Fact]
        public void StartTaskFromPull_double_launch_of_single_task_throw_exception()
        {
            var pool = new MicroThreadPool();
            var task = new Task(CalculateSum);

            async void CalculateSum()
            {
                int a = 100_000, b = 2_000;
                Debug.WriteLine($"Sum {a + b}");
                await Task.Delay(100);
            }

            pool.AddTaskToPool(task);
            pool.AddTaskToPool(task);

            Type type = typeof(InvalidOperationException);
            Assert.Throws(exceptionType: type, testCode: () =>
            {
                pool.StartTaskFromPool(task.Id);
                pool.StartTaskFromPool(task.Id);
            });
        }

        [Fact]
        public void StartTaskPull_non_existent_in_pool_throw_exception()
        {
            var pool = new MicroThreadPool();

            Type type = typeof(NullReferenceException);
            Assert.Throws(exceptionType: type, testCode: () => pool.StartTaskFromPool(6));
        }
    }
}