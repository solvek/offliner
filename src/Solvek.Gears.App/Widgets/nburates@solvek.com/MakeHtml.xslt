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
					<xsl:apply-templates select="resultSet"/>
				</body>
			</html>
		</xsl:template>
		<xsl:template match="widgetInfo">
			<div id="titleBar">
				<img alt="Іконка віджету" widht="16px" height="16px">
					<xsl:attribute name="src"><xsl:value-of select="icon"/></xsl:attribute>
				</img>
				<span style="padding-left:5px"/>
				<a>
					<xsl:attribute name="href"><xsl:value-of select="widgetUrl"/></xsl:attribute>
					<xsl:value-of select="name"/>
				</a>				
			</div>			
		</xsl:template>
		<xsl:template match="status">
			<div id="subTitle">
				<span style="padding-left:10px">Останнє оновлення: <xsl:value-of select="substring(LastUpdate,1,10)"/></span>
			</div>			
		</xsl:template>
		<xsl:template match="date">
			<p>Дані на <xsl:value-of select="span"/></p>
		</xsl:template>		
		<xsl:template match="rates/table">
			<ul>
				<xsl:for-each select="tr[@class='G1' or @class='w1']">
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
		</xsl:template>
		<xsl:template match="authorInfo">
			<div id="subTitle">
				<span>Автор віджету: </span>
				<a>
					<xsl:attribute name="href"><xsl:value-of select="authorUrl"/></xsl:attribute>
					<xsl:value-of select="author"/>
				</a>
			</div>
		</xsl:template>
		<xsl:template match="copyright">
			<div id="copyright">За даними сайту 
				<a>
					<xsl:attribute name="href"><xsl:value-of select="sourceSite"/></xsl:attribute>
					<xsl:value-of select="sourceSite"/>
				</a>
			</div>
		</xsl:template>
</xsl:stylesheet>