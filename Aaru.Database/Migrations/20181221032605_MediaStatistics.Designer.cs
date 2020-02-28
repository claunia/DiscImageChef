﻿// <auto-generated />
using System;
using Aaru.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aaru.Database.Migrations
{
    [DbContext(typeof(AaruContext))]
    [Migration("20181221032605_MediaStatistics")]
    partial class MediaStatistics
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Ata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Identify");

                    b.Property<int?>("ReadCapabilitiesId");

                    b.HasKey("Id");

                    b.HasIndex("ReadCapabilitiesId");

                    b.ToTable("Ata");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.BlockDescriptor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint?>("BlockLength");

                    b.Property<ulong?>("Blocks");

                    b.Property<byte>("Density");

                    b.Property<int?>("ScsiModeId");

                    b.HasKey("Id");

                    b.HasIndex("ScsiModeId");

                    b.ToTable("BlockDescriptor");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Chs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<ushort>("Cylinders");

                    b.Property<ushort>("Heads");

                    b.Property<ushort>("Sectors");

                    b.HasKey("Id");

                    b.ToTable("Chs");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.DensityCode", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SscSupportedMediaId");

                    b.HasKey("Code");

                    b.HasIndex("SscSupportedMediaId");

                    b.ToTable("DensityCode");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.FireWire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Product");

                    b.Property<uint>("ProductID");

                    b.Property<bool>("RemovableMedia");

                    b.Property<uint>("VendorID");

                    b.HasKey("Id");

                    b.ToTable("FireWire");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Mmc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FeaturesId");

                    b.HasKey("Id");

                    b.HasIndex("FeaturesId");

                    b.ToTable("Mmc");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.MmcFeatures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte?>("AACSVersion");

                    b.Property<byte?>("AGIDs");

                    b.Property<byte?>("BindingNonceBlocks");

                    b.Property<ushort?>("BlocksPerReadableUnit");

                    b.Property<bool>("BufferUnderrunFreeInDVD");

                    b.Property<bool>("BufferUnderrunFreeInSAO");

                    b.Property<bool>("BufferUnderrunFreeInTAO");

                    b.Property<byte?>("CPRMVersion");

                    b.Property<byte?>("CSSVersion");

                    b.Property<bool>("CanAudioScan");

                    b.Property<bool>("CanEject");

                    b.Property<bool>("CanEraseSector");

                    b.Property<bool>("CanExpandBDRESpareArea");

                    b.Property<bool>("CanFormat");

                    b.Property<bool>("CanFormatBDREWithoutSpare");

                    b.Property<bool>("CanFormatCert");

                    b.Property<bool>("CanFormatFRF");

                    b.Property<bool>("CanFormatQCert");

                    b.Property<bool>("CanFormatRRM");

                    b.Property<bool>("CanGenerateBindingNonce");

                    b.Property<bool>("CanLoad");

                    b.Property<bool>("CanMuteSeparateChannels");

                    b.Property<bool>("CanOverwriteSAOTrack");

                    b.Property<bool>("CanOverwriteTAOTrack");

                    b.Property<bool>("CanPlayCDAudio");

                    b.Property<bool>("CanPseudoOverwriteBDR");

                    b.Property<bool>("CanReadAllDualR");

                    b.Property<bool>("CanReadAllDualRW");

                    b.Property<bool>("CanReadBD");

                    b.Property<bool>("CanReadBDR");

                    b.Property<bool>("CanReadBDRE1");

                    b.Property<bool>("CanReadBDRE2");

                    b.Property<bool>("CanReadBDROM");

                    b.Property<bool>("CanReadBluBCA");

                    b.Property<bool>("CanReadCD");

                    b.Property<bool>("CanReadCDMRW");

                    b.Property<bool>("CanReadCPRM_MKB");

                    b.Property<bool>("CanReadDDCD");

                    b.Property<bool>("CanReadDVD");

                    b.Property<bool>("CanReadDVDPlusMRW");

                    b.Property<bool>("CanReadDVDPlusR");

                    b.Property<bool>("CanReadDVDPlusRDL");

                    b.Property<bool>("CanReadDVDPlusRW");

                    b.Property<bool>("CanReadDVDPlusRWDL");

                    b.Property<bool>("CanReadDriveAACSCertificate");

                    b.Property<bool>("CanReadHDDVD");

                    b.Property<bool>("CanReadHDDVDR");

                    b.Property<bool>("CanReadHDDVDRAM");

                    b.Property<bool>("CanReadLeadInCDText");

                    b.Property<bool>("CanReadOldBDR");

                    b.Property<bool>("CanReadOldBDRE");

                    b.Property<bool>("CanReadOldBDROM");

                    b.Property<bool>("CanReadSpareAreaInformation");

                    b.Property<bool>("CanReportDriveSerial");

                    b.Property<bool>("CanReportMediaSerial");

                    b.Property<bool>("CanTestWriteDDCDR");

                    b.Property<bool>("CanTestWriteDVD");

                    b.Property<bool>("CanTestWriteInSAO");

                    b.Property<bool>("CanTestWriteInTAO");

                    b.Property<bool>("CanUpgradeFirmware");

                    b.Property<bool>("CanWriteBD");

                    b.Property<bool>("CanWriteBDR");

                    b.Property<bool>("CanWriteBDRE1");

                    b.Property<bool>("CanWriteBDRE2");

                    b.Property<bool>("CanWriteBusEncryptedBlocks");

                    b.Property<bool>("CanWriteCDMRW");

                    b.Property<bool>("CanWriteCDRW");

                    b.Property<bool>("CanWriteCDRWCAV");

                    b.Property<bool>("CanWriteCDSAO");

                    b.Property<bool>("CanWriteCDTAO");

                    b.Property<bool>("CanWriteCSSManagedDVD");

                    b.Property<bool>("CanWriteDDCDR");

                    b.Property<bool>("CanWriteDDCDRW");

                    b.Property<bool>("CanWriteDVDPlusMRW");

                    b.Property<bool>("CanWriteDVDPlusR");

                    b.Property<bool>("CanWriteDVDPlusRDL");

                    b.Property<bool>("CanWriteDVDPlusRW");

                    b.Property<bool>("CanWriteDVDPlusRWDL");

                    b.Property<bool>("CanWriteDVDR");

                    b.Property<bool>("CanWriteDVDRDL");

                    b.Property<bool>("CanWriteDVDRW");

                    b.Property<bool>("CanWriteHDDVDR");

                    b.Property<bool>("CanWriteHDDVDRAM");

                    b.Property<bool>("CanWriteOldBDR");

                    b.Property<bool>("CanWriteOldBDRE");

                    b.Property<bool>("CanWritePackedSubchannelInTAO");

                    b.Property<bool>("CanWriteRWSubchannelInSAO");

                    b.Property<bool>("CanWriteRWSubchannelInTAO");

                    b.Property<bool>("CanWriteRaw");

                    b.Property<bool>("CanWriteRawMultiSession");

                    b.Property<bool>("CanWriteRawSubchannelInTAO");

                    b.Property<bool>("ChangerIsSideChangeCapable");

                    b.Property<byte>("ChangerSlots");

                    b.Property<bool>("ChangerSupportsDiscPresent");

                    b.Property<bool>("DBML");

                    b.Property<bool>("DVDMultiRead");

                    b.Property<bool>("EmbeddedChanger");

                    b.Property<bool>("ErrorRecoveryPage");

                    b.Property<DateTime?>("FirmwareDate");

                    b.Property<byte?>("LoadingMechanismType");

                    b.Property<bool>("Locked");

                    b.Property<uint?>("LogicalBlockSize");

                    b.Property<bool>("MultiRead");

                    b.Property<uint?>("PhysicalInterfaceStandardNumber");

                    b.Property<bool>("PreventJumper");

                    b.Property<bool>("SupportsAACS");

                    b.Property<bool>("SupportsBusEncryption");

                    b.Property<bool>("SupportsC2");

                    b.Property<bool>("SupportsCPRM");

                    b.Property<bool>("SupportsCSS");

                    b.Property<bool>("SupportsDAP");

                    b.Property<bool>("SupportsDeviceBusyEvent");

                    b.Property<bool>("SupportsHybridDiscs");

                    b.Property<bool>("SupportsModePage1Ch");

                    b.Property<bool>("SupportsOSSC");

                    b.Property<bool>("SupportsPWP");

                    b.Property<bool>("SupportsSWPP");

                    b.Property<bool>("SupportsSecurDisc");

                    b.Property<bool>("SupportsSeparateVolume");

                    b.Property<bool>("SupportsVCPS");

                    b.Property<bool>("SupportsWriteInhibitDCB");

                    b.Property<bool>("SupportsWriteProtectPAC");

                    b.Property<ushort?>("VolumeLevels");

                    b.HasKey("Id");

                    b.ToTable("MmcFeatures");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.MmcSd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("CID");

                    b.Property<byte[]>("CSD");

                    b.Property<byte[]>("ExtendedCSD");

                    b.Property<byte[]>("OCR");

                    b.Property<byte[]>("SCR");

                    b.HasKey("Id");

                    b.ToTable("MmcSd");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Pcmcia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("CIS");

                    b.Property<ushort?>("CardCode");

                    b.Property<string>("Compliance");

                    b.Property<string>("Manufacturer");

                    b.Property<ushort?>("ManufacturerCode");

                    b.Property<string>("ProductName");

                    b.HasKey("Id");

                    b.ToTable("Pcmcia");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Scsi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("InquiryData");

                    b.Property<byte[]>("ModeSense10Data");

                    b.Property<byte[]>("ModeSense6Data");

                    b.Property<int?>("ModeSenseId");

                    b.Property<int?>("MultiMediaDeviceId");

                    b.Property<int?>("ReadCapabilitiesId");

                    b.Property<int?>("SequentialDeviceId");

                    b.Property<bool>("SupportsModeSense10");

                    b.Property<bool>("SupportsModeSense6");

                    b.Property<bool>("SupportsModeSubpages");

                    b.HasKey("Id");

                    b.HasIndex("ModeSenseId");

                    b.HasIndex("MultiMediaDeviceId");

                    b.HasIndex("ReadCapabilitiesId");

                    b.HasIndex("SequentialDeviceId");

                    b.ToTable("Scsi");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.ScsiMode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("BlankCheckEnabled");

                    b.Property<byte?>("BufferedMode");

                    b.Property<bool>("DPOandFUA");

                    b.Property<byte?>("MediumType");

                    b.Property<byte?>("Speed");

                    b.Property<bool>("WriteProtected");

                    b.HasKey("Id");

                    b.ToTable("ScsiMode");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.ScsiPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ScsiId");

                    b.Property<int?>("ScsiModeId");

                    b.Property<byte>("page");

                    b.Property<byte?>("subpage");

                    b.Property<byte[]>("value");

                    b.HasKey("Id");

                    b.HasIndex("ScsiId");

                    b.HasIndex("ScsiModeId");

                    b.ToTable("ScsiPage");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Ssc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte?>("BlockSizeGranularity");

                    b.Property<uint?>("MaxBlockLength");

                    b.Property<uint?>("MinBlockLength");

                    b.HasKey("Id");

                    b.ToTable("Ssc");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.SscSupportedMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<ushort>("Length");

                    b.Property<byte>("MediumType");

                    b.Property<string>("Name");

                    b.Property<string>("Organization");

                    b.Property<int?>("SscId");

                    b.Property<int?>("TestedSequentialMediaId");

                    b.Property<ushort>("Width");

                    b.HasKey("Id");

                    b.HasIndex("SscId");

                    b.HasIndex("TestedSequentialMediaId");

                    b.ToTable("SscSupportedMedia");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.SupportedDensity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("BitsPerMm");

                    b.Property<uint>("Capacity");

                    b.Property<bool>("DefaultDensity");

                    b.Property<string>("Description");

                    b.Property<bool>("Duplicate");

                    b.Property<string>("Name");

                    b.Property<string>("Organization");

                    b.Property<byte>("PrimaryCode");

                    b.Property<byte>("SecondaryCode");

                    b.Property<int?>("SscId");

                    b.Property<int?>("TestedSequentialMediaId");

                    b.Property<ushort>("Tracks");

                    b.Property<ushort>("Width");

                    b.Property<bool>("Writable");

                    b.HasKey("Id");

                    b.HasIndex("SscId");

                    b.HasIndex("TestedSequentialMediaId");

                    b.ToTable("SupportedDensity");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.TestedMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtaId");

                    b.Property<uint?>("BlockSize");

                    b.Property<ulong?>("Blocks");

                    b.Property<int?>("CHSId");

                    b.Property<bool?>("CanReadAACS");

                    b.Property<bool?>("CanReadADIP");

                    b.Property<bool?>("CanReadATIP");

                    b.Property<bool?>("CanReadBCA");

                    b.Property<bool?>("CanReadC2Pointers");

                    b.Property<bool?>("CanReadCMI");

                    b.Property<bool?>("CanReadCorrectedSubchannel");

                    b.Property<bool?>("CanReadCorrectedSubchannelWithC2");

                    b.Property<bool?>("CanReadDCB");

                    b.Property<bool?>("CanReadDDS");

                    b.Property<bool?>("CanReadDMI");

                    b.Property<bool?>("CanReadDiscInformation");

                    b.Property<bool?>("CanReadFirstTrackPreGap");

                    b.Property<bool?>("CanReadFullTOC");

                    b.Property<bool?>("CanReadHDCMI");

                    b.Property<bool?>("CanReadLayerCapacity");

                    b.Property<bool?>("CanReadLeadIn");

                    b.Property<bool?>("CanReadLeadOut");

                    b.Property<bool?>("CanReadMediaID");

                    b.Property<bool?>("CanReadMediaSerial");

                    b.Property<bool?>("CanReadPAC");

                    b.Property<bool?>("CanReadPFI");

                    b.Property<bool?>("CanReadPMA");

                    b.Property<bool?>("CanReadPQSubchannel");

                    b.Property<bool?>("CanReadPQSubchannelWithC2");

                    b.Property<bool?>("CanReadPRI");

                    b.Property<bool?>("CanReadRWSubchannel");

                    b.Property<bool?>("CanReadRWSubchannelWithC2");

                    b.Property<bool?>("CanReadRecordablePFI");

                    b.Property<bool?>("CanReadSpareAreaInformation");

                    b.Property<bool?>("CanReadTOC");

                    b.Property<int?>("CurrentCHSId");

                    b.Property<byte?>("Density");

                    b.Property<byte[]>("IdentifyData");

                    b.Property<ulong?>("LBA48Sectors");

                    b.Property<uint?>("LBASectors");

                    b.Property<ushort?>("LogicalAlignment");

                    b.Property<uint?>("LongBlockSize");

                    b.Property<string>("Manufacturer");

                    b.Property<bool>("MediaIsRecognized");

                    b.Property<byte?>("MediumType");

                    b.Property<string>("MediumTypeName");

                    b.Property<int?>("MmcId");

                    b.Property<byte[]>("ModeSense10Data");

                    b.Property<byte[]>("ModeSense6Data");

                    b.Property<string>("Model");

                    b.Property<ushort?>("NominalRotationRate");

                    b.Property<uint?>("PhysicalBlockSize");

                    b.Property<int?>("ScsiId");

                    b.Property<bool?>("SolidStateDevice");

                    b.Property<bool?>("SupportsHLDTSTReadRawDVD");

                    b.Property<bool?>("SupportsNECReadCDDA");

                    b.Property<bool?>("SupportsPioneerReadCDDA");

                    b.Property<bool?>("SupportsPioneerReadCDDAMSF");

                    b.Property<bool?>("SupportsPlextorReadCDDA");

                    b.Property<bool?>("SupportsPlextorReadRawDVD");

                    b.Property<bool?>("SupportsRead10");

                    b.Property<bool?>("SupportsRead12");

                    b.Property<bool?>("SupportsRead16");

                    b.Property<bool?>("SupportsRead6");

                    b.Property<bool?>("SupportsReadCapacity");

                    b.Property<bool?>("SupportsReadCapacity16");

                    b.Property<bool?>("SupportsReadCd");

                    b.Property<bool?>("SupportsReadCdMsf");

                    b.Property<bool?>("SupportsReadCdMsfRaw");

                    b.Property<bool?>("SupportsReadCdRaw");

                    b.Property<bool?>("SupportsReadDma");

                    b.Property<bool?>("SupportsReadDmaLba");

                    b.Property<bool?>("SupportsReadDmaLba48");

                    b.Property<bool?>("SupportsReadDmaRetry");

                    b.Property<bool?>("SupportsReadDmaRetryLba");

                    b.Property<bool?>("SupportsReadLba");

                    b.Property<bool?>("SupportsReadLba48");

                    b.Property<bool?>("SupportsReadLong");

                    b.Property<bool?>("SupportsReadLong16");

                    b.Property<bool?>("SupportsReadLongLba");

                    b.Property<bool?>("SupportsReadLongRetry");

                    b.Property<bool?>("SupportsReadLongRetryLba");

                    b.Property<bool?>("SupportsReadRetry");

                    b.Property<bool?>("SupportsReadRetryLba");

                    b.Property<bool?>("SupportsReadSectors");

                    b.Property<bool?>("SupportsSeek");

                    b.Property<bool?>("SupportsSeekLba");

                    b.Property<ushort?>("UnformattedBPS");

                    b.Property<ushort?>("UnformattedBPT");

                    b.HasKey("Id");

                    b.HasIndex("AtaId");

                    b.HasIndex("CHSId");

                    b.HasIndex("CurrentCHSId");

                    b.HasIndex("MmcId");

                    b.HasIndex("ScsiId");

                    b.ToTable("TestedMedia");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.TestedSequentialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("CanReadMediaSerial");

                    b.Property<byte?>("Density");

                    b.Property<string>("Manufacturer");

                    b.Property<bool>("MediaIsRecognized");

                    b.Property<byte?>("MediumType");

                    b.Property<string>("MediumTypeName");

                    b.Property<byte[]>("ModeSense10Data");

                    b.Property<byte[]>("ModeSense6Data");

                    b.Property<string>("Model");

                    b.Property<int?>("SscId");

                    b.HasKey("Id");

                    b.HasIndex("SscId");

                    b.ToTable("TestedSequentialMedia");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Usb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Descriptors");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Product");

                    b.Property<ushort>("ProductID");

                    b.Property<bool>("RemovableMedia");

                    b.Property<ushort>("VendorID");

                    b.HasKey("Id");

                    b.ToTable("Usb");
                });

            modelBuilder.Entity("Aaru.Database.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("Synchronized");

                    b.HasKey("Id");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("Aaru.Database.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ATAId");

                    b.Property<int?>("ATAPIId");

                    b.Property<bool>("CompactFlash");

                    b.Property<int?>("FireWireId");

                    b.Property<DateTime>("LastSynchronized");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Model");

                    b.Property<int?>("MultiMediaCardId");

                    b.Property<int?>("PCMCIAId");

                    b.Property<string>("Revision");

                    b.Property<int?>("SCSIId");

                    b.Property<int?>("SecureDigitalId");

                    b.Property<int>("Type");

                    b.Property<int?>("USBId");

                    b.HasKey("Id");

                    b.HasIndex("ATAId");

                    b.HasIndex("ATAPIId");

                    b.HasIndex("FireWireId");

                    b.HasIndex("MultiMediaCardId");

                    b.HasIndex("PCMCIAId");

                    b.HasIndex("SCSIId");

                    b.HasIndex("SecureDigitalId");

                    b.HasIndex("USBId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Aaru.Database.Models.Filesystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("Synchronized");

                    b.HasKey("Id");

                    b.ToTable("Filesystems");
                });

            modelBuilder.Entity("Aaru.Database.Models.Filter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("Synchronized");

                    b.HasKey("Id");

                    b.ToTable("Filters");
                });

            modelBuilder.Entity("Aaru.Database.Models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Real");

                    b.Property<bool>("Synchronized");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("Aaru.Database.Models.MediaFormat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("Synchronized");

                    b.HasKey("Id");

                    b.ToTable("MediaFormats");
                });

            modelBuilder.Entity("Aaru.Database.Models.Partition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("Synchronized");

                    b.HasKey("Id");

                    b.ToTable("Partitions");
                });

            modelBuilder.Entity("Aaru.Database.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ATAId");

                    b.Property<int?>("ATAPIId");

                    b.Property<bool>("CompactFlash");

                    b.Property<DateTime>("Created");

                    b.Property<int?>("FireWireId");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Model");

                    b.Property<int?>("MultiMediaCardId");

                    b.Property<int?>("PCMCIAId");

                    b.Property<string>("Revision");

                    b.Property<int?>("SCSIId");

                    b.Property<int?>("SecureDigitalId");

                    b.Property<int>("Type");

                    b.Property<int?>("USBId");

                    b.Property<bool>("Uploaded");

                    b.HasKey("Id");

                    b.HasIndex("ATAId");

                    b.HasIndex("ATAPIId");

                    b.HasIndex("FireWireId");

                    b.HasIndex("MultiMediaCardId");

                    b.HasIndex("PCMCIAId");

                    b.HasIndex("SCSIId");

                    b.HasIndex("SecureDigitalId");

                    b.HasIndex("USBId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Aaru.Decoders.SCSI.Modes+ModePage_2A", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AccurateCDDA");

                    b.Property<bool>("AudioPlay");

                    b.Property<bool>("BCK");

                    b.Property<bool>("BUF");

                    b.Property<ushort>("BufferSize");

                    b.Property<bool>("C2Pointer");

                    b.Property<bool>("CDDACommand");

                    b.Property<ushort>("CMRSupported");

                    b.Property<bool>("Composite");

                    b.Property<ushort>("CurrentSpeed");

                    b.Property<ushort>("CurrentWriteSpeed");

                    b.Property<ushort>("CurrentWriteSpeedSelected");

                    b.Property<bool>("DeinterlaveSubchannel");

                    b.Property<bool>("DigitalPort1");

                    b.Property<bool>("DigitalPort2");

                    b.Property<bool>("Eject");

                    b.Property<bool>("ISRC");

                    b.Property<bool>("LSBF");

                    b.Property<bool>("LeadInPW");

                    b.Property<byte>("Length");

                    b.Property<byte>("LoadingMechanism");

                    b.Property<bool>("Lock");

                    b.Property<bool>("LockState");

                    b.Property<ushort>("MaxWriteSpeed");

                    b.Property<ushort>("MaximumSpeed");

                    b.Property<bool>("Method2");

                    b.Property<bool>("Mode2Form1");

                    b.Property<bool>("Mode2Form2");

                    b.Property<bool>("MultiSession");

                    b.Property<bool>("PS");

                    b.Property<bool>("PreventJumper");

                    b.Property<bool>("RCK");

                    b.Property<bool>("ReadBarcode");

                    b.Property<bool>("ReadCDR");

                    b.Property<bool>("ReadCDRW");

                    b.Property<bool>("ReadDVDR");

                    b.Property<bool>("ReadDVDRAM");

                    b.Property<bool>("ReadDVDROM");

                    b.Property<byte>("RotationControlSelected");

                    b.Property<bool>("SCC");

                    b.Property<bool>("SDP");

                    b.Property<bool>("SSS");

                    b.Property<bool>("SeparateChannelMute");

                    b.Property<bool>("SeparateChannelVolume");

                    b.Property<bool>("Subchannel");

                    b.Property<ushort>("SupportedVolumeLevels");

                    b.Property<bool>("TestWrite");

                    b.Property<bool>("UPC");

                    b.Property<bool>("WriteCDR");

                    b.Property<bool>("WriteCDRW");

                    b.Property<bool>("WriteDVDR");

                    b.Property<bool>("WriteDVDRAM");

                    b.HasKey("Id");

                    b.ToTable("ModePage_2A");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Ata", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.TestedMedia", "ReadCapabilities")
                        .WithMany()
                        .HasForeignKey("ReadCapabilitiesId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.BlockDescriptor", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.ScsiMode")
                        .WithMany("BlockDescriptors")
                        .HasForeignKey("ScsiModeId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.DensityCode", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.SscSupportedMedia")
                        .WithMany("DensityCodes")
                        .HasForeignKey("SscSupportedMediaId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Mmc", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.MmcFeatures", "Features")
                        .WithMany()
                        .HasForeignKey("FeaturesId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.Scsi", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.ScsiMode", "ModeSense")
                        .WithMany()
                        .HasForeignKey("ModeSenseId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Mmc", "MultiMediaDevice")
                        .WithMany()
                        .HasForeignKey("MultiMediaDeviceId");

                    b.HasOne("Aaru.CommonTypes.Metadata.TestedMedia", "ReadCapabilities")
                        .WithMany()
                        .HasForeignKey("ReadCapabilitiesId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Ssc", "SequentialDevice")
                        .WithMany()
                        .HasForeignKey("SequentialDeviceId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.ScsiPage", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.Scsi")
                        .WithMany("EVPDPages")
                        .HasForeignKey("ScsiId");

                    b.HasOne("Aaru.CommonTypes.Metadata.ScsiMode")
                        .WithMany("ModePages")
                        .HasForeignKey("ScsiModeId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.SscSupportedMedia", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.Ssc")
                        .WithMany("SupportedMediaTypes")
                        .HasForeignKey("SscId");

                    b.HasOne("Aaru.CommonTypes.Metadata.TestedSequentialMedia")
                        .WithMany("SupportedMediaTypes")
                        .HasForeignKey("TestedSequentialMediaId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.SupportedDensity", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.Ssc")
                        .WithMany("SupportedDensities")
                        .HasForeignKey("SscId");

                    b.HasOne("Aaru.CommonTypes.Metadata.TestedSequentialMedia")
                        .WithMany("SupportedDensities")
                        .HasForeignKey("TestedSequentialMediaId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.TestedMedia", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.Ata")
                        .WithMany("RemovableMedias")
                        .HasForeignKey("AtaId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Chs", "CHS")
                        .WithMany()
                        .HasForeignKey("CHSId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Chs", "CurrentCHS")
                        .WithMany()
                        .HasForeignKey("CurrentCHSId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Mmc")
                        .WithMany("TestedMedia")
                        .HasForeignKey("MmcId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Scsi")
                        .WithMany("RemovableMedias")
                        .HasForeignKey("ScsiId");
                });

            modelBuilder.Entity("Aaru.CommonTypes.Metadata.TestedSequentialMedia", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.Ssc")
                        .WithMany("TestedMedia")
                        .HasForeignKey("SscId");
                });

            modelBuilder.Entity("Aaru.Database.Models.Device", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.Ata", "ATA")
                        .WithMany()
                        .HasForeignKey("ATAId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Ata", "ATAPI")
                        .WithMany()
                        .HasForeignKey("ATAPIId");

                    b.HasOne("Aaru.CommonTypes.Metadata.FireWire", "FireWire")
                        .WithMany()
                        .HasForeignKey("FireWireId");

                    b.HasOne("Aaru.CommonTypes.Metadata.MmcSd", "MultiMediaCard")
                        .WithMany()
                        .HasForeignKey("MultiMediaCardId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Pcmcia", "PCMCIA")
                        .WithMany()
                        .HasForeignKey("PCMCIAId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Scsi", "SCSI")
                        .WithMany()
                        .HasForeignKey("SCSIId");

                    b.HasOne("Aaru.CommonTypes.Metadata.MmcSd", "SecureDigital")
                        .WithMany()
                        .HasForeignKey("SecureDigitalId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Usb", "USB")
                        .WithMany()
                        .HasForeignKey("USBId");
                });

            modelBuilder.Entity("Aaru.Database.Models.Report", b =>
                {
                    b.HasOne("Aaru.CommonTypes.Metadata.Ata", "ATA")
                        .WithMany()
                        .HasForeignKey("ATAId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Ata", "ATAPI")
                        .WithMany()
                        .HasForeignKey("ATAPIId");

                    b.HasOne("Aaru.CommonTypes.Metadata.FireWire", "FireWire")
                        .WithMany()
                        .HasForeignKey("FireWireId");

                    b.HasOne("Aaru.CommonTypes.Metadata.MmcSd", "MultiMediaCard")
                        .WithMany()
                        .HasForeignKey("MultiMediaCardId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Pcmcia", "PCMCIA")
                        .WithMany()
                        .HasForeignKey("PCMCIAId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Scsi", "SCSI")
                        .WithMany()
                        .HasForeignKey("SCSIId");

                    b.HasOne("Aaru.CommonTypes.Metadata.MmcSd", "SecureDigital")
                        .WithMany()
                        .HasForeignKey("SecureDigitalId");

                    b.HasOne("Aaru.CommonTypes.Metadata.Usb", "USB")
                        .WithMany()
                        .HasForeignKey("USBId");
                });
#pragma warning restore 612, 618
        }
    }
}
