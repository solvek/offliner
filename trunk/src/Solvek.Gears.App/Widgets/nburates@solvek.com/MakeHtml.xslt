<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:output method="xhtml" version="1.0" encoding="UTF-8" indent="yes"/>
		<xsl:template match="/">
			<html>
				<head>
					<title>Офіційні курси валют</title>
				</head>
				<body>
					<xsl:apply-templates select="/html/body/table/tbody/tr/td/div"/>
				</body>
			</html>
		</xsl:template>
		<xsl:template match="form[@id='tableForm']">
			<p><img src="nbu.png" alt="НБУ лого"/>Дані на <xsl:value-of select="p/br/span"/></p>
			<ul>
				<xsl:for-each select="table/tr[@class='G1' or @class='w1']">
					<li><xsl:value-of select="td[3]"/>&#160;<xsl:value-of select="td[4]"/> = <xsl:value-of select="td[5]"/> грн</li>
				</xsl:for-each>
			</ul>
		</xsl:template>
</xsl:stylesheet>
