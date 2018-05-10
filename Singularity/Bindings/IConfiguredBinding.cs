﻿using System.Linq.Expressions;

namespace Singularity.Bindings
{
	public interface IConfiguredBinding
	{
		Expression Expression { get; }
		Lifetime Lifetime { get; }
	}
}