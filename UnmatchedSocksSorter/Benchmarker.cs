using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using UnmatchedSocksSorter.Data;

namespace UnmatchedSocksSorter
{
    [MemoryDiagnoser]
    public class Benchmarker
    {
        private readonly Sorter sorter = new Sorter();
        private List<Sock> templateData;
        private List<Sock> unmatchedSocks;

        [GlobalSetup]
        public void GlobalSetup()
        {
            this.templateData = SockGenerator.GenerateSocks(500000);
        }

        [IterationSetup]
        public void IterationSetup()
        {
            this.unmatchedSocks = this.templateData.ToList();
        }

        [Benchmark]
        public List<Sock> NaiveSort()
        {
            return this.sorter.NaiveSort(this.unmatchedSocks);
        }

        [Benchmark]
        public List<Sock> NaivePartialSort()
        {
            return this.sorter.NaivePartialSort(this.unmatchedSocks);
        }

        [Benchmark]
        public List<Sock> OneLevelPileSort()
        {
            return this.sorter.OneLevelPileSort(this.unmatchedSocks);
        }

        [Benchmark]
        public List<Sock> ThreeLevelPileSort()
        {
            return this.sorter.ThreeLevelPileSort(this.unmatchedSocks);
        }

        [Benchmark]
        public List<Sock> DictionarySort()
        {
            return this.sorter.DictionarySort(this.unmatchedSocks);
        }
    }
}
