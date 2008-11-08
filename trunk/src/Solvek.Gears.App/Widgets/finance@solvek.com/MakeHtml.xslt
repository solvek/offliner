<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes">
	<xsl:template match="/">
		<html>
			<head>
				<title>Фінансова інформація</title>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
				<link type="text/css" rel="stylesheet" href="../common/common.css"/>
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
			<span style="padding-left:10px">Останнє оновлення: <xsl:value-of select="substring(LastUpdate,1,10)"/>
			</span>
		</div>
	</xsl:template>
	<xsl:template match="rates">
		<ul>
			<xsl:call-template name="item">
				<xsl:with-param name="data" select="tr[3]"/>
				<xsl:with-param name="class" select="'evenRow'"/>
				<xsl:with-param name="text" select="'Готівка'"/>
			</xsl:call-template>
			<xsl:call-template name="item">
				<xsl:with-param name="data" select="tr[4]"/>
				<xsl:with-param name="class" select="'oddRow'"/>
				<xsl:with-param name="text" select="'Готівка'"/>
			</xsl:call-template>			
			<xsl:call-template name="item">
				<xsl:with-param name="data" select="tr[5]"/>
				<xsl:with-param name="class" select="'evenRow'"/>
				<xsl:with-param name="text" select="'Готівка'"/>
			</xsl:call-template>	
			<xsl:call-template name="item">
				<xsl:with-param name="data" select="tr[13]"/>
				<xsl:with-param name="class" select="'oddRow'"/>
				<xsl:with-param name="text" select="'Форекс'"/>
			</xsl:call-template>
			<xsl:call-template name="item">
				<xsl:with-param name="data" select="tr[14]"/>
				<xsl:with-param name="class" select="'evenRow'"/>
				<xsl:with-param name="text" select="'Форекс'"/>
			</xsl:call-template>			
			<xsl:call-template name="item">
				<xsl:with-param name="data" select="tr[15]"/>
				<xsl:with-param name="class" select="'oddRow'"/>
				<xsl:with-param name="text" select="'Форекс'"/>
			</xsl:call-template>				
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
	<xsl:template name="item">
		<xsl:param name="data"/>
		<xsl:param name="class"/>
		<xsl:param name="text"/>
		<li>
			<xsl:attribute name="class"><xsl:value-of select="$class"/></xsl:attribute>
			<xsl:value-of select="$text"/>&#160;
			<xsl:value-of select="$data/td[1]"/>&#160;
			<xsl:for-each select="$data/td">
				<xsl:if test="position() != 1">
					<xsl:value-of select="."/>&#160;
				</xsl:if>				
			</xsl:for-each> 
		</li>
	</xsl:template>
</xsl:stylesheet>
