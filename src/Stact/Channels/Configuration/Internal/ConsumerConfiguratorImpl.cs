﻿// Copyright 2010 Chris Patterson
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Stact.Configuration.Internal
{
	using Builders;


	public class ConsumerConfiguratorImpl<TChannel> :
		FiberFactoryConfiguratorImpl<ConsumerConfigurator<TChannel>>,
		ConsumerConfigurator<TChannel>,
		ChannelBuilderConfigurator<TChannel>
	{
		readonly Consumer<TChannel> _consumer;

		public ConsumerConfiguratorImpl(Consumer<TChannel> consumer)
		{
			_consumer = consumer;
		}

		public void ValidateConfiguration()
		{
			if (_consumer == null)
				throw new ChannelConfigurationException(typeof(TChannel), "Consumer cannot be null");

			ValidateFiberFactoryConfiguration();
		}

		public void Configure(ChannelBuilder<TChannel> builder)
		{
			Fiber fiber = GetConfiguredFiber(builder);

			builder.AddChannel(fiber, x => new ConsumerChannel<TChannel>(x, _consumer));
		}
	}
}