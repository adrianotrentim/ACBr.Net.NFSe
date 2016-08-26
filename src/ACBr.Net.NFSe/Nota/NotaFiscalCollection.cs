// ***********************************************************************
// Assembly         : ACBr.Net.NFe
// Author           : RFTD
// Created          : 10-01-2014
//
// Last Modified By : RFTD
// Last Modified On : 10-01-2014
// ***********************************************************************
// <copyright file="NotaFiscalCollection.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Collection;
using ACBr.Net.NFSe.Providers;
using System.IO;
using System.Text;
using System.Xml;

namespace ACBr.Net.NFSe.Nota
{
	/// <summary>
	/// Classe NotaFiscalCollection. Est� classe n�o pode ser herdada.
	/// </summary>
	public sealed class NotaFiscalCollection : DFeCollection<NotaFiscal>
	{
		#region Constructor

		/// <summary>
		/// Inicializa uma nova instacia da classe <see cref="NotaFiscalCollection"/>.
		/// </summary>
		/// <param name="parent">The parent.</param>
		internal NotaFiscalCollection(ACBrNFSe parent)
		{
			Parent = parent;
		}

		#endregion Constructor

		#region Propriedades

		/// <summary>
		/// Gets the parent.
		/// </summary>
		/// <value>The parent.</value>
		public ACBrNFSe Parent { get; }

		#endregion Propriedades

		#region Methods

		/// <summary>
		/// Adiciona uma nova nota fiscal na cole��o.
		/// </summary>
		/// <returns>T.</returns>
		public override NotaFiscal AddNew()
		{
			var nota = new NotaFiscal();
			nota.Prestador = Parent.Configuracoes.PrestadorPadrao;
			Add(nota);
			return nota;
		}

        /// <summary>
        /// Carrega a NFSe/RPS do arquivo.
        /// </summary>
        /// <param name="xml">caminho do arquivo XML ou string com o XML.</param>
		/// <param name="encoding">encoding do XML.</param>
        /// <returns>NotaFiscal carregada.</returns>
        public NotaFiscal Load(string xml, Encoding encoding = null)
		{
			var provider = ProviderManager.GetProvider(Parent.Configuracoes);
			var nota = provider.LoadXml(xml, encoding);
			Add(nota);
			return nota;
		}

		/// <summary>
		/// Carrega a NFSe/RPS do xml.
		/// </summary>
		/// <param name="stream">Stream do XML.</param>
		/// <returns>NotaFiscal carregada.</returns>
		public NotaFiscal Load(Stream stream)
		{
			var provider = ProviderManager.GetProvider(Parent.Configuracoes);
			var nota = provider.LoadXml(stream);
			Add(nota);
			return nota;
		}

		/// <summary>
		/// Carrega a NFSe/RPS do XMLDocument.
		/// </summary>
		/// <param name="xml">XMLDocument da NFSe/RPS.</param>
		/// <returns>NotaFiscal carregada.</returns>
		public NotaFiscal Load(XmlDocument xml)
		{
			var provider = ProviderManager.GetProvider(Parent.Configuracoes);
			var nota = provider.LoadXml(xml);
			Add(nota);
			return nota;
		}

		#endregion Methods
	}
}