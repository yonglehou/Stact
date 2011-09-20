// Copyright 2010 Chris Patterson
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
namespace Stact.Routing.Internal
{
    using Contexts;


    public class ConvertNode<TInput, TOutput> :
        Activation<TInput>
        where TInput : TOutput
    {
        Activation<TOutput> _output;

        public ConvertNode(Activation<TOutput> output)
        {
            _output = output;
        }

        public Activation<TOutput> Output
        {
            get { return _output; }
        }

        public bool Enabled
        {
            get { return _output.Enabled; }
        }

        public void Activate(RoutingContext<TInput> context)
        {
            context.Convert<TOutput>(proxy => _output.Activate(proxy));
        }
    }
}