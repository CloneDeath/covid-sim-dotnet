using System;
using CovidSim.Models;
using CovidSim.TBD1;
using FluentAssertions;
using NUnit.Framework;

namespace CovidSim.Tests.TBD1;

[TestFixture]
public abstract class KernelLookup_tests {
    [TestFixture]
    public class KernelLookup_Setup_Tests : KernelLookup_tests
    {
        [Test]
        public void Setup_CalculatesDeltaCorrectly()
        {
            var kernelLookup = new KernelLookup();
            double longestDistance = 100.0;

            kernelLookup.setup(longestDistance);

            kernelLookup.size_.Should().Be(4000000);
            kernelLookup.delta_.Should().BeApproximately(longestDistance / kernelLookup.size_, 1e-12);
        }

        [Test]
        public void Setup_EnsuresCountForLookupTables()
        {
            var kernelLookup = new KernelLookup();
            double longestDistance = 100.0;

            kernelLookup.setup(longestDistance);

            kernelLookup.lookup_.Count.Should().Be(kernelLookup.size_ + 1);
            kernelLookup.hi_res_.Count.Should().Be(kernelLookup.size_ + 1);
        }
    }

    [TestFixture]
    public class KernelLookup_Init_Tests : KernelLookup_tests
    {
        [Test]
        public void Init_ThrowsForUnknownKernelType()
        {
            var kernelLookup = new KernelLookup {
                expansion_factor_ = 1
            };
            var kernel = new KernelStruct {
                type_ = 99,
                scale_ = 1
            };

            var act = () => kernelLookup.init(1.0, kernel);

            act.Should().Throw<ArgumentException>().WithMessage("Unknown kernel type 99.");
        }

        [Test]
        public void Init_SetsLookupValuesCorrectly()
        {
            var kernelLookup = new KernelLookup {
                expansion_factor_ = 1
            };
            kernelLookup.setup(100.0);
            var kernel = new KernelStruct {
                type_ = 1,
                scale_ = 1
            };

            kernelLookup.init(1.0, kernel);

            kernelLookup.lookup_[0].Should().BeApproximately(1.0, 1e-12);
            kernelLookup.hi_res_[0].Should().BeApproximately(1.0, 1e-12);
        }
    }

    [TestFixture]
    public class KernelLookup_Num_Tests : KernelLookup_tests
    {
        [Test]
        public void Num_ThrowsIfR2TooLarge()
        {
            var kernelLookup = new KernelLookup {
                expansion_factor_ = 1
            };
            kernelLookup.setup(100.0);

            Action act = () => kernelLookup.num(200.0);

            act.Should().Throw<Exception>().WithMessage("r too large in NumKernel, r2: 200, delta_: *, size_: *, t: *");
        }

        [Test]
        public void Num_PerformsLookupCorrectly()
        {
            var kernelLookup = new KernelLookup {
                expansion_factor_ = 1
            };
            kernelLookup.setup(100.0);
            var kernel = new KernelStruct {
                type_ = 1,
                scale_ = 1
            };
            kernelLookup.init(1.0, kernel);

            double result = kernelLookup.num(25.0);

            result.Should().BeGreaterThan(0.0);
        }
    }

    [TestFixture]
    public class KernelLookup_StaticInit_Tests : KernelLookup_tests
    {
        [Test]
        public void StaticInit_SetsCellProbabilitiesCorrectly()
        {
            var kernelLookup = new KernelLookup {
                expansion_factor_ = 1
            };
            kernelLookup.setup(100.0);
            var kernel = new KernelStruct {
                type_ = 1,
                scale_ = 1
            };
            kernelLookup.init(1.0, kernel);

            var cells = new[]
            {
                new Cell { n = 1 },
                new Cell { n = 2 }
            };
            foreach (var cell in cells)
            {
                cell.max_trans = new float[2];
            }

            KernelLookup.init(kernelLookup, cells, cells.Length);

            cells[0].tot_prob.Should().BeGreaterThan(0);
            cells[1].tot_prob.Should().BeGreaterThan(0);
        }
    }
}
