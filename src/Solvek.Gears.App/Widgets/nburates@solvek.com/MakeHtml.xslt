<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="xhtml" version="1.0" encoding="UTF-8" indent="yes"/>
		<xsl:template match="/">
			<html>
				<head>
					<title>Офіційні курси валют</title>
					<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
					<link type="text/css" rel="stylesheet" href="../common/common.css" />
				</head>
				<body>
					<xsl:apply-templates select="html/body/table/tbody/tr/td/div"/>
				</body>
			</html>
		</xsl:template>
		<xsl:template match="form[@id='tableForm']">
			<div id="titleBar">
				<img src="nbu.png" alt="Іконка віджету" widht="16px" height="16px"/>
				<span style="padding-left:5px"/>
				<a href="http://www.solvek.com/gears">Курси НБУ</a>				
			</div>
			<div id="subTitle">
				<span style="padding-left:10px">Останнє оновлення: 2008-10-30</span>
			</div>
			<p>Дані на <xsl:value-of select="p/br/span"/></p>
			<ul>
				<xsl:for-each select="table/tr[@class='G1' or @class='w1']">
					<li>
						<xsl:choose>
							<xsl:when test="position() mod 2 = 1">
								<xsl:attribute name="class">evenRow</xsl:attribute>
							</xsl:when>
							<xsl:otherwise>
								<xsl:attribute name="class">oddRow</xsl:attribute>
							</xsl:otherwise>
						</xsl:choose>							
						<xsl:value-of select="td[3]"/>&#160;<xsl:value-of select="td[4]"/>&#160;
						<span>
							<xsl:if test="td[1] = '840' or td[1] = '978'">
								<xsl:attribute name="style">font-weight: bold;</xsl:attribute>
							</xsl:if>
							<xsl:value-of select="td[5]"/>
						</span>
					</li>
				</xsl:for-each>
			</ul>
			<div id="subTitle">
				<span>Автор віджету: </span>
				<a href="http://www.solvek.com">Сергій Адамчук</a>
			</div>
		</xsl:template>
</xsl:stylesheet>