package com.ctfo.storage.util;

/**
 * 
 * 
 * <p>
 * ----------------------------------------------------------------------------- <br>
 * 工程名 ： SspDispatchService <br>
 * 功能： Base64编解码<br>
 * 描述： Base64编解码<br>
 * 授权 : (C) Copyright (c) 2011 <br>
 * 公司 : 北京中交慧联信息科技有限公司 <br>
 * ----------------------------------------------------------------------------- <br>
 * 修改历史 <br>
 * <table width="432" border="1">
 * <tr>
 * <td>版本</td>
 * <td>时间</td>
 * <td>作者</td>
 * <td>改变</td>
 * </tr>
 * <tr>
 * <td>1.0</td>
 * <td>2014-11-3</td>
 * <td>xuehui</td>
 * <td>创建</td>
 * </tr>
 * </table>
 * <br>
 * <font color="#FF0000">注意: 本内容仅限于[北京中交慧联信息科技有限公司]内部使用，禁止转发</font> <br>
 * 
 * @version 1.0
 * 
 * @author xuehui
 * @since JDK1.6
 */
public final class Base64_URl {

	public static final String Base64Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

	/**
	 * Encoding a string to a string follow the Base64 regular
	 * 
	 * @param s
	 * @return
	 */
	public static String base64Encode(final String s) {
		if (s == null || s.length() == 0)
			return s;

		byte[] b = null;
		try {
			b = s.getBytes("UTF-8");
		} catch (java.io.UnsupportedEncodingException e) {
			e.printStackTrace();
			return s;
		}

		return base64EncodeFoArray(b);

	}

	/**
	 * Encoding a byte array to a string follow the Base64 regular.
	 * 
	 * @param s
	 *            byte array
	 * @return
	 */
	public static String base64EncodeFoArray(final byte[] s) {
		if (s == null)
			return null;
		if (s.length == 0)
			return "";

		StringBuffer buf = new StringBuffer();

		int b0, b1, b2, b3;
		int len = s.length;
		int i = 0;
		while (i < len) {
			byte tmp = s[i++];
			b0 = (tmp & 0xfc) >> 2;
			b1 = (tmp & 0x03) << 4;
			if (i < len) {
				tmp = s[i++];
				b1 |= (tmp & 0xf0) >> 4;
				b2 = (tmp & 0x0f) << 2;
				if (i < len) {
					tmp = s[i++];
					b2 |= (tmp & 0xc0) >> 6;
					b3 = tmp & 0x3f;
				} else {
					b3 = 64; // 1 byte "-" is supplement

				}
			} else {
				b2 = b3 = 64;// 2 bytes "-" are supplement

			}

			buf.append(Base64Chars.charAt(b0));
			buf.append(Base64Chars.charAt(b1));
			buf.append(Base64Chars.charAt(b2));
			buf.append(Base64Chars.charAt(b3));
		}

		return buf.toString();
	}

	/**
	 * Decoding a string to a string follow the Base64 regular.
	 * 
	 * @param s
	 * @return
	 */
	public static String base64Decode(final String s) {
		byte[] b = base64DecodeToArray(s);
		if (b == null)
			return null;
		if (b.length == 0)
			return "";

		try {
			return new String(b, "UTF-8");
		} catch (java.io.UnsupportedEncodingException e) {
			e.printStackTrace();
			return null;
		}

	}

	/**
	 * Decoding a string to a byte array follow the Base64 regular
	 * 
	 * @param s
	 * @return
	 */
	public static byte[] base64DecodeToArray(final String s) {
		if (s == null)
			return null;

		int len = s.length();
		if (len == 0)
			return new byte[0];
		if (len % 4 != 0) {
			throw new java.lang.IllegalArgumentException(s);
		}

		byte[] b = new byte[(len / 4) * 3];
		int i = 0, j = 0, e = 0, c, tmp;
		while (i < len) {
			c = Base64Chars.indexOf((int) s.charAt(i++));
			tmp = c << 18;
			c = Base64Chars.indexOf((int) s.charAt(i++));
			tmp |= c << 12;
			c = Base64Chars.indexOf((int) s.charAt(i++));
			if (c < 64) {
				tmp |= c << 6;
				c = Base64Chars.indexOf((int) s.charAt(i++));
				if (c < 64) {
					tmp |= c;
				} else {
					e = 1;
				}
			} else {
				e = 2;
				i++;
			}

			b[j + 2] = (byte) (tmp & 0xff);
			tmp >>= 8;
			b[j + 1] = (byte) (tmp & 0xff);
			tmp >>= 8;
			b[j + 0] = (byte) (tmp & 0xff);
			j += 3;
		}

		if (e != 0) {
			len = b.length - e;
			byte[] copy = new byte[len];
			System.arraycopy(b, 0, copy, 0, len);
			return copy;
		}
		return b;
	}

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		String s0 = "aa";
		String s1 = base64Encode(s0);
		System.err.println(s0 + " -->" + s1);
		String s2 = base64Decode(s1);
		System.err.println(s1 + " --> " + s2);
	}

}
