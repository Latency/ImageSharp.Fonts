﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SixLabors.Fonts.Tables;
using SixLabors.Fonts.Tables.General;

using Xunit;

namespace SixLabors.Fonts.Tests
{
    public class FontReaderTests
    {
        [Fact]
        public void ReadTrueTypeOutlineType()
        {
            var writer = new BinaryWriter();
            writer.WriteTrueTypeFileHeader(0, 0, 0, 0);

            var reader = new FontReader(writer.GetStream());
            Assert.Equal(FontReader.OutlineTypes.TrueType, reader.OutlineType);
        }

        [Fact]
        public void ReadCcfOutlineType()
        {
            var writer = new BinaryWriter();
            writer.WriteCffFileHeader(0, 0, 0, 0);

            var reader = new FontReader(writer.GetStream());
            Assert.Equal(FontReader.OutlineTypes.CFF, reader.OutlineType);
        }

        [Fact]
        public void ReadTableHeaders()
        {
            var writer = new BinaryWriter();
            writer.WriteTrueTypeFileHeader(2, 0, 0, 0);
            writer.WriteTableHeader("TAG1", 0, 10, 0);
            writer.WriteTableHeader("TAG2", 0, 1, 0);

            var reader = new FontReader(writer.GetStream());

            Assert.Equal(2, reader.Tables.Length);
            var names = reader.Tables.OfType<UnknownTable>().Select(x => x.Name);
            Assert.Contains("TAG1", names);
            Assert.Contains("TAG2", names);
        }

        [Fact]
        public void ReadTableHeadersSkipTables()
        {
            var writer = new BinaryWriter();
            writer.WriteTrueTypeFileHeader(2, 0, 0, 0);
            writer.WriteTableHeader("TAG1", 0, 10, 0);
            writer.WriteTableHeader("TAG2", 0, 1, 0);


            var reader = new FontReader(writer.GetStream(), new[] { typeof(NameTable) });

            // found not matching types
            Assert.Equal(0, reader.Tables.Length);
        }


        [Fact]
        public void ReadCMapTable()
        {
            var writer = new BinaryWriter();

            writer.WriteTrueTypeFileHeader(new TableHeader("cmap", 0, 0, 20));

            writer.WriteCMapTable(new[] {
                new SixLabors.Fonts.Tables.General.CMap.Format0SubTable(0, WellKnownIds.PlatformIDs.Macintosh, 1, new byte[] {2,9})
            });

            var reader = new FontReader(writer.GetStream());
            var cmap = reader.GetTable<CMapTable>();
            Assert.NotNull(cmap);

            // found not matching types
            Assert.Equal(1, reader.Tables.Length);
        }
    }
}
