using System;
using System.IO;
using System.Text;

/// <summary>
/// 提供用于计算指定文件哈希值的方法
/// <example>例如计算文件的MD5值:
/// <code>
///   String hashMd5=HashHelper.GetMD5("MyFile.txt");
/// </code>
/// </example>
/// <example>例如计算文件的CRC32值:
/// <code>
///   String hashCrc32 = HashHelper.GetCRC32("MyFile.txt");
/// </code>
/// </example>
/// <example>例如计算文件的SHA1值:
/// <code>
///   String hashSha1 =HashHelper.GetSHA1("MyFile.txt");
/// </code>
/// </example>
/// </summary>
public class HashHelper
{
	/// <summary>
	///  计算指定文件的MD5值
	/// </summary>
	/// <param name="fileName">指定文件的完全限定名称</param>
	/// <returns>返回值的字符串形式</returns>
	public static String GetMD5(String fileName)
	{
		String hashMD5 = String.Empty;
		//检查文件是否存在，如果文件存在则进行计算，否则返回空值
		if (File.Exists(fileName))
		{
			using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				//计算文件的MD5值
				System.Security.Cryptography.MD5 calculator = System.Security.Cryptography.MD5.Create();
				Byte[] buffer = calculator.ComputeHash(fs);
				calculator.Clear();
				//将字节数组转换成十六进制的字符串形式
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < buffer.Length; i++)
				{
					stringBuilder.Append(buffer[i].ToString("x2"));
				}
				hashMD5 = stringBuilder.ToString();
			}//关闭文件流
		}//结束计算
		return hashMD5;
	}//ComputeMD5

	/// <summary>
	///  计算指定文件的CRC32值
	/// </summary>
	/// <param name="fileName">指定文件的完全限定名称</param>
	/// <returns>返回值的字符串形式</returns>
	public static String GetCRC32(String fileName)
	{
		String hashCRC32 = String.Empty;
		//检查文件是否存在，如果文件存在则进行计算，否则返回空值
		if (File.Exists(fileName))
		{
			using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				//计算文件的CSC32值
				XCrc32 calculator = new XCrc32();
				Byte[] buffer = calculator.ComputeHash(fs);
				calculator.Clear();
				//将字节数组转换成十六进制的字符串形式
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < buffer.Length; i++)
				{
					stringBuilder.Append(buffer[i].ToString("x2"));
				}
				hashCRC32 = stringBuilder.ToString();
			}//关闭文件流
		}
		return hashCRC32;
	}//ComputeCRC32


	/// <summary>
	/// 获取文件的SHA1
	/// </summary>
	/// <param name="fileName"></param>
	/// <returns></returns>
	public static String GetSHA1(String fileName)
	{
		String hashSHA1 = String.Empty;
		//检查文件是否存在，如果文件存在则进行计算，否则返回空值
		if (File.Exists(fileName))
		{
			using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				//计算文件的SHA1值
				System.Security.Cryptography.SHA1 calculator = System.Security.Cryptography.SHA1.Create();
				Byte[] buffer = calculator.ComputeHash(fileStream);
				calculator.Clear();
				//将字节数组转换成十六进制的字符串形式
				StringBuilder stringBuilder = new StringBuilder();
				for (int bufferIdx = 0; bufferIdx < buffer.Length; bufferIdx++)
				{
					stringBuilder.Append(buffer[bufferIdx].ToString("x2"));
				}
				hashSHA1 = stringBuilder.ToString();

			}//关闭文件流
		}
		else
		{
			Console.Error.WriteLine("{0}文件找不到！", fileName);
		}
		return hashSHA1;
	}//end GetSHA1
}

/// <summary>
/// 提供 CRC32 算法的实现
/// </summary>
public class XCrc32 : System.Security.Cryptography.HashAlgorithm
{
	public const UInt32 DefaultPolynomial = 0xedb88320;
	public const UInt32 DefaultSeed = 0xffffffff;
	private UInt32 hash;
	private UInt32 seed;
	private UInt32[] table;
	private static UInt32[] defaultTable;
	public XCrc32()
	{
		table = InitializeTable(DefaultPolynomial);
		seed = DefaultSeed;
		Initialize();
	}
	public XCrc32(UInt32 polynomial, UInt32 seed)
	{
		table = InitializeTable(polynomial);
		this.seed = seed;
		Initialize();
	}
	public override void Initialize()
	{
		hash = seed;
	}
	protected override void HashCore(byte[] buffer, int start, int length)
	{
		hash = CalculateHash(table, hash, buffer, start, length);
	}
	protected override byte[] HashFinal()
	{
		byte[] hashBuffer = UInt32ToBigEndianBytes(~hash);
		this.HashValue = hashBuffer;
		return hashBuffer;
	}
	public static UInt32 Compute(byte[] buffer)
	{
		return ~CalculateHash(InitializeTable(DefaultPolynomial), DefaultSeed, buffer, 0, buffer.Length);
	}
	public static UInt32 Compute(UInt32 seed, byte[] buffer)
	{
		return ~CalculateHash(InitializeTable(DefaultPolynomial), seed, buffer, 0, buffer.Length);
	}
	public static UInt32 Compute(UInt32 polynomial, UInt32 seed, byte[] buffer)
	{
		return ~CalculateHash(InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
	}
	private static UInt32[] InitializeTable(UInt32 polynomial)
	{
		if (polynomial == DefaultPolynomial && defaultTable != null)
		{
			return defaultTable;
		}
		UInt32[] createTable = new UInt32[256];
		for (int i = 0; i < 256; i++)
		{
			UInt32 entry = (UInt32)i;
			for (int j = 0; j < 8; j++)
			{
				if ((entry & 1) == 1)
					entry = (entry >> 1) ^ polynomial;
				else
					entry = entry >> 1;
			}
			createTable[i] = entry;
		}
		if (polynomial == DefaultPolynomial)
		{
			defaultTable = createTable;
		}
		return createTable;
	}
	private static UInt32 CalculateHash(UInt32[] table, UInt32 seed, byte[] buffer, int start, int size)
	{
		UInt32 crc = seed;
		for (int i = start; i < size; i++)
		{
			unchecked
			{
				crc = (crc >> 8) ^ table[buffer[i] ^ crc & 0xff];
			}
		}
		return crc;
	}
	private byte[] UInt32ToBigEndianBytes(UInt32 x)
	{
		return new byte[] { (byte)((x >> 24) & 0xff), (byte)((x >> 16) & 0xff), (byte)((x >> 8) & 0xff), (byte)(x & 0xff) };
	}
}//end class: XCrc32