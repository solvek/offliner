<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:xs="http://www.w3.org/2001/XMLSchema" 
	xmlns:fn="http://www.w3.org/2005/xpath-functions" 
	xmlns:xdt="http://www.w3.org/2005/xpath-datatypes"
	xmlns:aw="http://www.accuweather.com">
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
		<xsl:template match="days">
			<ul>
				<xsl:for-each select="aw:day">
					<li>
						<xsl:choose>
							<xsl:when test="position() mod 2 = 1">
								<xsl:attribute name="class">evenRow</xsl:attribute>
							</xsl:when>
							<xsl:otherwise>
								<xsl:attribute name="class">oddRow</xsl:attribute>
							</xsl:otherwise>
						</xsl:choose>							
						<xsl:value-of select="aw:obsdate"/>
						<img slt="Опис">
							<xsl:attribute name="src">
								<xsl:value-of select="concat('icons/', aw:daytime/aw:weathericon, '.png')"/>
							</xsl:attribute>
						</img>
						<a>
							<xsl:attribute name="href">
								<xsl:value-of select="aw:url"/>
							</xsl:attribute>						
							<xsl:value-of select="aw:daytime/aw:lowtemperature"/>..
							<xsl:value-of select="aw:daytime/aw:hightemperature"/>
						</a>
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